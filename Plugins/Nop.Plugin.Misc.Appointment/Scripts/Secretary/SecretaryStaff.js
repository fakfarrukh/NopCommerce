
function LoadStaffList() {
    $.ajax({
        url: "/Secretary/StaffList",
        type: "GET",
        dataType: "text",
        success: function (res) {

            $("#content").html(res);
            $("#StaffList").dxDataGrid({
                dataSource: {
                    store: {
                        type: "odata",
                        url: "/Secretary/StaffListItem",
                        key: "Id",
                    },
                },
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
                columns: [
                    {
                        type: "buttons",
                        width: 110,
                        buttons: [
                            {
                                hint: "edit",
                                icon: "edit",

                                onClick(e) {
                                    LoadStaffDeatil(e.row.data);
                                },
                            },
                            {
                                hint: "delete",
                                icon: "trash",

                                onClick(e) {
                                    if (confirm("Are you sure!") == true) {
                                        $.ajax({
                                            url: "/Secretary/DeleteStaff?staffId=" + e.row.data.Id,
                                            type: "delete",
                                            dataType: "text",
                                            success: function (res) {
                                                e.component.refresh(true);
                                            },
                                        });
                                    }
                                },
                            },
                        ],
                    },
                    ,
                    {
                        dataField: "GivenName",
                        caption: "Given Name",
                        dataType: "string",
                    },
                    {
                        dataField: "ReferenceId",
                        caption: "Reference",
                        dataType: "string",
                    },
                ],
                toolbar: {
                    items: [
                        {
                            staff: "after",
                            widget: "dxButton",
                            options: {
                                icon: "plus",
                                onClick() {
                                    //dataGrid.refresh();

                                    LoadAddStaff();
                                },
                            },
                        },
                        "columnChooserButton",
                    ],
                },
            });
        },
    });
}
function LoadAddStaff() {
    $.ajax({
        url: "/Secretary/AddStaff",
        type: "GET",
        dataType: "text",
        success: function (res) {
            $("#content").html(res);

            const formData = {
                ReferenceId: "",
                IsOwner: true,
                Status: 0,
                GivenName: "",
                FamilyName: "",
                EmailAddress: "",
                PhoneNumber: "",
                Title: "",
            };

            const formWidget = $("#form")
                .dxForm({
                    formData,
                    readOnly: false,
                    showColonAfterLabel: true,
                    showValidationSummary: true,
                    validationGroup: "customerData",
                    items: [
                        {
                            itemType: "group",
                            caption: "Staff Profile",
                            colCount: 2,
                            items: [
                                {
                                    dataField: "Title",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Title is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "ReferenceId",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Reference Id is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "GivenName",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Given Name is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "FamilyName",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Family Name is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "IsOwner",
                                }
                                ,
                                {
                                    dataField: "Status",
                                    editorType: "dxSelectBox",
                                    editorOptions: {
                                        items: ["ACTIVE", "INACTIVE"],


                                    },
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Status is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "EmailAddress", validationRules: [{
                                        type: 'email',
                                        message: 'Email is invalid',
                                    }
                                    ]
                                }, 
                                {
                                    dataField: "PhoneNumber",
                                },
                            ],
                        },

                        {
                            itemType: "button",

                            colCount: 2,
                            horizontalAlignment: "left",
                            buttonOptions: {
                                text: "Save",
                                type: "success",
                                useSubmitBehavior: true,
                            },
                        },
                    ],
                })
                .dxForm("instance");
            submited = false;
            $(document).on("submit", "#form-add-staff", (e) => {
                if (submited) { LoadStaffList(); return; }
                e.preventDefault();

                var form = document.getElementById("form-add-staff");
                $('input[type="submit"]').prop('disabled', true);



                var a = $("form#form-add-staff").serializeArray();

                var staff = {
                    ReferenceId: a.find((a) => {
                        return a.name === "ReferenceId";
                    }).value,
                    IsOwner: a.find((a) => {
                        return a.name === "IsOwner";
                    }).value,
                    Status: a.find((a) => {
                        return a.name === "Status";
                    }).value,

                    GivenName: a.find((a) => {
                        return a.name === "GivenName";
                    }).value,
                    FamilyName: a.find((a) => {
                        return a.name === "FamilyName";
                    }).value,
                    EmailAddress: a.find((a) => {
                        return a.name === "EmailAddress";
                    }).value,
                    PhoneNumber: a.find((a) => {
                        return a.name === "PhoneNumber";
                    }).value,
                    Title: a.find((a) => {
                        return a.name === "Title";
                    }).value,
                };

                $.ajax({
                    url: "/Secretary/AddStaff",
                    type: "post",
                    data: staff,

                    success: function (res) {
                        submited = true;
                        DevExpress.ui.notify(
                            {
                                message: "You have submitted the form",
                                position: {
                                    my: "center top",
                                    at: "center top",
                                },
                            },
                            "success",
                            3500
                        );
                        LoadStaffList();
                    },
                });


            });
        },
    });
}
function LoadStaffDeatil(data) {
    const accordionItems = [
        {
            Title: "Profile & Business Hours",
        },
        {
            Title: "Staff Locations",
        }
    ];



    $.ajax({
        url: "/Secretary/StaffById",
        type: "GET",
        dataType: "text",
        success: function (res) {
            $("#content").html(res);




            //var accordion = $("#accordion-container").dxAccordion({
            //    dataSource: accordionItems,
            //    animationDuration: 300,
            //    collapsible: false,
            //    multiple: false,
            //    selectedItems: [accordionItems[0]],
            //    itemTitleTemplate: $("#AccordionTemplateTitle"),
            //    itemTemplate: $("#AccordionTemplate"),
            //});


            $.ajax({
                url: "/Secretary/StaffDetail?StaffId=" + data.Id,
                type: "GET",
                dataType: "text",
                success: function (res1) {
                    var item = JSON.parse(res1);

                    var weekday = [
                        { Id: 1, Name: "Sunday" },
                        { Id: 2, Name: "Monday" },
                        { Id: 3, Name: "Tuesday" },
                        { Id: 4, Name: "Wednesday" },
                        { Id: 5, Name: "Thursday" },
                        { Id: 6, Name: "Friday" },
                        { Id: 7, Name: "Saturday" },
                    ];

                    const weekdayStore = new DevExpress.data.ArrayStore({
                        key: "Id",
                        data: weekday,
                    });

                    //const items = {
                    //    store: {
                    //        type: "odata",
                    //        url: "/Secretary/LocationListItem",
                    //        key: "Id",
                    //    },
                    //}




                    const businessHoursList = new DevExpress.data.ArrayStore({
                        key: "BusinessHourId",
                        data: item.StaffBusinessHours,
                    });


                    $.ajax({
                        url: "/Secretary/LocationListItem",
                        type: "GET",
                        dataType: "text",
                        success: function (locations) {


                            var locationItems = [];
                            JSON.parse(locations).data.forEach((data) => {
                                locationItems.push({ Name: data.Name, Id: data.Id })
                            })



                            const locationsStore = new DevExpress.data.ArrayStore({
                                key: "Id",
                                data: locationItems,
                            });


                            var dataGrid = $("#BusinessHoursList").dxDataGrid({
                                editing: {
                                    allowUpdating: true,
                                    allowAdding: true,
                                    allowDeleting: true,
                                    mode: "batch",
                                },
                                dataSource: businessHoursList,
                                paging: {
                                    pageSize: 100,
                                },
                                repaintChangesOnly: true,
                                remoteOperations: false,

                                showBorders: true,
                                columns: [
                                    {
                                        dataField: "LocationId",
                                        caption: "Location",
                                        dataType: "string",
                                        lookup: {
                                            dataSource: locationItems,
                                            displayExpr: "Name",
                                            valueExpr: "Id",
                                        },
                                        validationRules: [
                                            {
                                                type: "required",
                                                message: "Required",
                                            },
                                        ],
                                    },
                                    {
                                        dataField: "WeekDayId",
                                        caption: "WeekDay",
                                        dataType: "number",
                                        lookup: {
                                            dataSource: weekdayStore,
                                            displayExpr: "Name",
                                            valueExpr: "Id",
                                        },
                                        validationRules: [
                                            {
                                                type: "required",
                                                message: "Required",
                                            },
                                        ],
                                    },
                                    {
                                        dataField: "StartLocalTime",
                                        caption: "Start Local Time",

                                        lookup: { dataSource: time },
                                        validationRules: [{ type: "required", message: "Required" }],
                                    },
                                    {
                                        dataField: "EndLocalTime",
                                        caption: "End Local Time",

                                        lookup: { dataSource: time },
                                        validationRules: [{ type: "required", message: "Required" }],
                                    },
                                ],

                                onSaved(e) {
                                    var a = e.component.getDataSource()._items;

                                    var items = [];
                                    a.forEach((data) => {


                                        items.push({
                                            LocationId: data.LocationId,
                                            WeekDayId: data.WeekDayId,
                                            StartLocalTime: data.StartLocalTime,
                                            EndLocalTime: data.EndLocalTime,
                                        });
                                    });

                                    $.ajax({
                                        url: "/Secretary/UpdateStaffBusinessHours?staffId=" + data.Id,
                                        type: "put",
                                        data: {
                                            businessHours: items,
                                        },

                                        success: function (res) {
                                            DevExpress.ui.notify(
                                                {
                                                    message: "You have submitted the form",
                                                    position: {
                                                        my: "center top",
                                                        at: "center top",
                                                    },
                                                },
                                                "success",
                                                3500
                                            );
                                        },
                                    });
                                },
                                onEditCanceling() { },
                            });
                        }
                    })
                    const formData = {
                        ReferenceId: item.ReferenceId,
                        IsOwner: item.IsOwner,
                        Status: item.Status === 0 ? "ACTIVE" : "INACTIVE",
                        GivenName: item.GivenName,
                        FamilyName: item.FamilyName,
                        EmailAddress: item.EmailAddress,
                        PhoneNumber: item.PhoneNumber,
                        Title: item.Title,
                    };

                    const formWidget = $("#form")
                        .dxForm({
                            formData,
                            readOnly: false,
                            showColonAfterLabel: true,

                            caption: "Staff1",

                            items: [
                                {
                                    dataField: "Title",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Title is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "ReferenceId",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Reference Id is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "GivenName",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Given Name is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "FamilyName",
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Family Name is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "IsOwner",
                                },
                                {
                                    dataField: "Status",
                                    editorType: "dxSelectBox",
                                    editorOptions: {
                                        items: ["ACTIVE", "INACTIVE"],


                                    },
                                    validationRules: [
                                        {
                                            type: "required",
                                            message: "Status is required",
                                        },
                                    ],
                                },
                                {
                                    dataField: "EmailAddress", validationRules: [{
                                        type: 'email',
                                        message: 'Email is invalid',
                                    }
                                    ]
                                },
                                {
                                    dataField: "PhoneNumber",
                                },
                                {
                                    itemType: "button",
                                    horizontalAlignment: "left",
                                    buttonOptions: {
                                        text: "Save",
                                        type: "success",
                                        useSubmitBehavior: true,
                                    },
                                },
                            ],
                        })
                        .dxForm("instance");

                    $(document).on("submit", "#form-edit-staff", (e) => {
                        e.preventDefault();
                        console.log("FFFFFFFFFff", e);
                        var a = $("form#form-edit-staff").serializeArray();
                        var staff = {
                            ReferenceId: a.find((a) => {
                                return a.name === "ReferenceId";
                            }).value,
                            IsOwner: a.find((a) => {
                                return a.name === "IsOwner";
                            }).value,
                            Status:
                                a.find((a) => {
                                    return a.name === "Status";
                                }).value === "ACTIVE"
                                    ? 0
                                    : 1,

                            GivenName: a.find((a) => {
                                return a.name === "GivenName";
                            }).value,
                            FamilyName: a.find((a) => {
                                return a.name === "FamilyName";
                            }).value,
                            EmailAddress: a.find((a) => {
                                return a.name === "EmailAddress";
                            }).value,
                            PhoneNumber: a.find((a) => {
                                return a.name === "PhoneNumber";
                            }).value,
                            Title: a.find((a) => {
                                return a.name === "Title";
                            }).value,
                        };

                        $.ajax({
                            url: "/Secretary/EditStaff?staffId=" + data.Id._value,
                            type: "put",
                            data: staff,

                            success: function (res) {
                                DevExpress.ui.notify(
                                    {
                                        message: "You have submitted the form",
                                        position: {
                                            my: "center top",
                                            at: "center top",
                                        },
                                    },
                                    "success",
                                    3500
                                );
                                LoadStaffList();
                            },
                        });
                    });
                },
            });
        },
    });
}
