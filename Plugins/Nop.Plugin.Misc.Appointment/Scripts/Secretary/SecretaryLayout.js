
$(() => {



    const insuranceStore = new DevExpress.data.CustomStore({
        key: 'Id',
        load() {

            return $.getJSON(`/Appointment/InsuranceList?vendorId=` + $('#Id').val());

        },
        insert(values) {


            console.log(values);
            var aaInsurance = {
                VendoreId: $('#Id').val(),
                Title: values.Title,

            };

            $.ajax({
                url: "/Appointment/AddInsurance",
                type: "post",
                data: aaInsurance,
                success: function (locations) {




                }
            })
           
        },
        update(key, values) {



            console.log(values);
            var aaInsurance = {
                Id: key,
                VendoreId: $('#Id').val(),
                Title: values.Title,

            };

            $.ajax({
                url: "/Appointment/AddInsurance",
                type: "post",
                data: aaInsurance,
                success: function (locations) {




                }
            })



        },
        remove(key) {

            $.ajax({
                url: "/Appointment/RemoveInsurance?id=" + key,
                type: "delete",
                dataType: "text",
                success: function (res) {
                    // e.component.refresh(true);
                },
            });



        },
    });







    $("#dataGridInsurance").dxDataGrid({
        dataSource: insuranceStore,
        paging: {
            pageSize: 50,
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [50, 100],
        },
        remoteOperations: false,
        searchPanel: {
            visible: true,
            highlightCaseSensitive: true,
        },
        groupPanel: { visible: true },
        grouping: {
            autoExpandAll: false,
        },
        allowColumnReordering: true,
        rowAlternationEnabled: true,
        showBorders: true,
        editing: {

            mode: 'row',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
        },
        columns: [


            {
                dataField: "Title",
                caption: "Company Name",
                dataType: "string",
            }
        ]

    });




































    const mapTypes = [{
        key: 'roadmap',
        name: 'Road Map',
    }, {
        key: 'satellite',
        name: 'Satellite (Photographic) Map',
    }, {
        key: 'hybrid',
        name: 'Hybrid Map',
    }];
    const map = $('#map').dxMap({
        center: { lat: 40.749825, lng: -73.987963 },
        zoom: 9,
        height: 250,
        width: '100%',
        provider: 'bing',
        apiKey: {
            // Specify your API keys for each map provider:
            // bing: "YOUR_BING_MAPS_API_KEY",
            // google: "YOUR_GOOGLE_MAPS_API_KEY",
            // googleStatic: "YOUR_GOOGLE_STATIC_MAPS_API_KEY"
        },
        type: mapTypes[0].key,
        onClick: function (e) {
            console.log(e);

            // $("#Latitude").val(e.location.lat);
            $("#Latitude").dxNumberBox({
                value: e.location.lat
            })
            $("#Longitude").dxNumberBox({
                value: e.location.lng
            })


        }
    }).dxMap('instance');



    const formData = {
        VendoreId: '',
        Longitude: '',
        Latitude: '',
        ParrentVendor: '',

    };
    //$.ajax({
    //    url: "/appointment/Location?id=1",
    //    type: "GET",
    //    dataType: "text",
    //    success: function (res) {


    var locationGroup = "locationGroup";
    $('#Latitude').dxNumberBox({
        onValueChanged: function (e) {

            const newValue = e.value;

        },
        min: -90,
        max: 90,

    }).dxValidator({
        validationRules: [{
            type: 'required'
        }],
        validationGroup: locationGroup
    });
    $('#Longitude').dxNumberBox({

        min: -90,
        max: 90,
    }).dxValidator({
        validationRules: [{
            type: 'required'
        }],
        validationGroup: locationGroup
    });


    $.ajax({
        url: "/Appointment/Vendors",
        type: "GET",
        dataType: "text",
        success: function (locations) {


            var locationItems = [];

            JSON.parse(locations).forEach((data) => {
                locationItems.push({ Name: data.Name, Id: data.Id })
            })



            const locationsStore = new DevExpress.data.ArrayStore({
                key: "Id",
                data: locationItems,
            });



            console.log(locationsStore);

            $.ajax({
                url: "/Appointment/location/" + $('#Id').val(),
                type: "GET",
                dataType: "text",
                success: function (locations) {

                    var item = JSON.parse(locations);
                    $('#map').dxMap({
                        center: { lat: item.Latitude, lng: item.Longitude, }
                    })

                    $('#Latitude').dxNumberBox({
                        value: item.Latitude,
                        onValueChanged: function (e) {

                            const newValue = e.value;

                        },
                        min: -90,
                        max: 90,

                    }).dxValidator({
                        validationRules: [{
                            type: 'required'
                        }],
                        validationGroup: locationGroup
                    });
                    $('#Longitude').dxNumberBox({
                        value: item.Longitude,
                        min: -90,
                        max: 90,
                    }).dxValidator({
                        validationRules: [{
                            type: 'required'
                        }],
                        validationGroup: locationGroup
                    });













                    $('#ParrentVendor').dxLookup({
                        dataSource: locationsStore,
                        dropDownOptions: {
                            hideOnOutsideClick: true,
                            showTitle: false,
                        },
                        displayExpr: "Name",
                        valueExpr: "Id",
                        value: item.ParrentVendor

                    }).dxValidator({
                        validationRules: [{
                            type: 'required'
                        }],
                        validationGroup: locationGroup
                    });

                }, error: function (err) {


                    $('#ParrentVendor').dxLookup({
                        dataSource: locationsStore,
                        dropDownOptions: {
                            hideOnOutsideClick: true,
                            showTitle: false,
                        },
                        displayExpr: "Name",
                        valueExpr: "Id"

                    }).dxValidator({
                        validationRules: [{
                            type: 'required'
                        }],
                        validationGroup: locationGroup
                    });

                }
            });



        }
    })



    $("#summary").dxValidationSummary({
        validationGroup: locationGroup
    });
    $("#button").dxButton({
        text: "Save Location",
        type: "success",
        stylingMode: "outlined",
        icon: "map",

        onClick: function (e) {


            var a = DevExpress.validationEngine.validateGroup("locationGroup");
            console.log(a);
            if (a.isValid) {

                var aaVendor = {
                    VendoreId: $('#Id').val(),
                    Longitude: $('#Longitude').dxNumberBox('instance').option('value'),
                    Latitude: $("#Latitude").dxNumberBox('instance').option('value'),

                    ParrentVendor: $('#ParrentVendor').dxLookup('instance').option('value'),

                };

                $.ajax({
                    url: "/Appointment/SaveLocation",
                    type: "post",
                    data: aaVendor,
                    success: function (locations) {




                    }
                })




            } else {

            }
        }

    })





});



