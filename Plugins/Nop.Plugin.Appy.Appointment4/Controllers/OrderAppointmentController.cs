using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Appy.Appointment4.Database;
using Nop.Plugin.Appy.Appointment4.Models;
using Nop.Plugin.Appy.Appointment4.Services.Interface;
using Nop.Services.Directory;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Orders;

namespace Nop.Plugin.Appy.Appointment4.Controllers
{
    public class OrderAppointmentController : BaseAdminController
    {
        private readonly DbContextAppointment _dbContextAppointment;
        private readonly IaaOrderList _aaOrderList;
        private readonly IOrderService _orderService;
        private readonly IPermissionService _permissionService;
        private readonly IOrderModelFactory _orderModelFactory;
        public OrderAppointmentController(DbContextAppointment dbContextAppointment, IaaOrderList orderList , IOrderService orderService,IPermissionService permissionService,IOrderModelFactory orderModelFactory)
        {
            _dbContextAppointment = dbContextAppointment;
            _aaOrderList = orderList;
            _orderService = orderService;
            _permissionService = permissionService;
            _orderModelFactory = orderModelFactory;
        }

        [HttpPost]
        public async Task<IActionResult> aaOrderDetails(OrderSearchModel searchModel)
        {
            try
            {
                if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageOrders))
                    return await AccessDeniedDataTablesJson();

                //prepare model
                var model = await _orderModelFactory.PrepareOrderListModelAsync(searchModel);

                if (model != null && model.Data.Any())
                {
                    var orderIds = model.Data.Select(x => x.Id).ToList();
                    var data = await _aaOrderList.GetaaOrdersAsync(orderIds.ToArray());
                    if (data != null && data.Count > 0)
                    {
                        foreach (var item in data)
                        {
                            var result = model.Data.Where(x => x.Id == item.OrderId).FirstOrDefault();
                            if (result != null)
                            {
                                result.CardId = item.cardID;
                                result.Date = item.appointmentDate != null ? item.appointmentDate.Value.Date : null;
                                result.FromTime = item.timeFrom != null ? item.timeFrom.Value.TimeOfDay : null;
                            }
                        }
                    }
                }
                return Json(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }
    }
}
