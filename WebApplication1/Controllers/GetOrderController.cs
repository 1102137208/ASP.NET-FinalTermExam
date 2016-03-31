using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class GetOrderController : Controller
    {
        // GET: GetOrder
        /// <summary>
        /// 訂單管理系統首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.OrderService orderService = new Models.OrderService();

            List<Models.Order> dataList = orderService.GetEmployeeData();
            List<SelectListItem> employeeList = new List<SelectListItem>();

            List<SelectListItem> shipperList = new List<SelectListItem>();

            foreach (var item in dataList)
            {
                employeeList.Add(new SelectListItem() {
                    Text = item.EmployeeName,
                    Value = item.EmployeeID.ToString(),
                });
            }
            ViewBag.empData = employeeList;

            dataList = orderService.GetShipperData();

            foreach (var item in dataList)
            {
                shipperList.Add(new SelectListItem()
                {

                    Text = item.ShipperName,
                    Value = item.ShipperID.ToString()
                });
            }

            ViewBag.shipperData = shipperList;

            return View();
        }

        [HttpPost]
        public JsonResult Index(Models.Order order)
        {
            Models.OrderService orderService = new Models.OrderService();
            List<Models.Order> list = orderService.GetOrderById(order);
            return this.Json(list);
        }
    }
}