﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GetOrderController : Controller
    {
        //GET: GetOrder
        /// <summary>
        /// 訂單管理系統首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllList()
        {
            Models.EmployeeService employeeService = new Models.EmployeeService();


           

            List<SelectListItem> employeeList = new List<SelectListItem>();

            //員工List
            List<Models.Employee> dataList = employeeService.GetEmployeeData();
            foreach (var item in dataList)
            {
                employeeList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.EmployeeID.ToString(),
                });
            }

            return this.Json(employeeList, JsonRequestBehavior.AllowGet);
        }

        /*
        /// <summary>
        /// 回傳訂單資料
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData(Employee order)
        {
            Models.EmployeeService orderService = new Models.EmployeeService();
            List<Models.Employee> list = orderService.SearchOrder(order);
            return this.Json(list);
        }

        /// <summary>
        /// 新增訂單頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertPage()
        {
            Models.EmployeeService orderService = new Models.EmployeeService();
            List<SelectListItem> productList = new List<SelectListItem>();
            //產品List
            foreach (var item in ProductList)
            {
                productList.Add(new SelectListItem()
                {
                    Text = item.ProductName,
                    Value = item.ProductID.ToString()
                });
            }

            ViewBag.productData = productList;
            return View();
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoInsert(Models.Employee order)
        {

            Models.EmployeeService orderService = new Models.EmployeeService();
            orderService.InsertOrder(order);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 修改訂單頁面
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public ActionResult UpdatePage(string OrderID)
        {
            Models.EmployeeService orderService = new Models.EmployeeService();

            List<Models.Employee> dataList = orderService.GetEmployeeData();
            List<Models.OrderDetails> ProductList = orderService.GetProductData();
            Models.Employee order = orderService.GetOrderById(OrderID);
            List<Models.OrderDetails> orderdetails = orderService.GetOrderDetialById(OrderID);

            List<SelectListItem> employeeList = new List<SelectListItem>();
            List<SelectListItem> shipperList = new List<SelectListItem>();
            List<SelectListItem> customerList = new List<SelectListItem>();
            List<SelectListItem> productList = new List<SelectListItem>();
            List<SelectListItem> unitpriceList = new List<SelectListItem>();
            List<List<SelectListItem>> getProductData = new List<List<SelectListItem>>();

            double total = 0;
            for (var i = 0; i < orderdetails.Count; i++) {
                double Qty = Convert.ToDouble(orderdetails[i].Qty);
                double UnitPrice = Convert.ToDouble(orderdetails[i].UnitPrice);
                total += Qty * UnitPrice;
            }
            ViewBag.Total = total + Convert.ToDouble(order.Freight);

            //員工List
            foreach (var item in dataList)
            {
                employeeList.Add(new SelectListItem()
                {
                    Text = item.EmployeeName,
                    Value = item.EmployeeID.ToString(),
                    Selected = item.EmployeeID.Equals(order.EmployeeID)
                });
            }
            ViewBag.empData = employeeList;

            //供應商List
            dataList = orderService.GetShipperData();
            foreach (var item in dataList)
            {
                shipperList.Add(new SelectListItem()
                {

                    Text = item.ShipperName,
                    Value = item.ShipperID.ToString(),
                    Selected = item.ShipperID.Equals(order.ShipperID)
                });
            }
            ViewBag.shipperData = shipperList;

            ///客戶List
            dataList = orderService.GetCustomerData();
            foreach (var item in dataList)
            {
                customerList.Add(new SelectListItem()
                {

                    Text = item.CustomerName,
                    Value = item.CustomerID.ToString(),
                    Selected = item.CustomerID.Equals(order.CustomerID)
                });
            }
            ViewBag.customerData = customerList;

            //產品List
            for (int i = 0; i < orderdetails.Count; i++)
            {
                foreach (var item in ProductList)
                {
                    productList.Add(new SelectListItem()
                    {
                        Text = item.ProductName,
                        Value = item.ProductID.ToString(),
                        Selected = item.ProductID.Equals(orderdetails[i].ProductID),
                    });
                }
                getProductData.Add(new List<SelectListItem>(productList));
                productList.Clear();
            }
            ViewBag.productData = getProductData;


            ProductList = orderService.GetPriceData();
            foreach (var item in ProductList)
            {
                unitpriceList.Add(new SelectListItem()
                {
                    Value = item.UnitPrice
                });
            }
            ViewBag.UnitPrice = unitpriceList;

            ViewBag.orderData = order;

            DateTime orderdate = Convert.ToDateTime(order.OrderDate);
            ViewBag.OrderDate = (orderdate.ToString("yyyy-MM-dd"));
            DateTime requireDdate = Convert.ToDateTime(order.RequiredDate);
            ViewBag.RequireDdate = (requireDdate.ToString("yyyy-MM-dd"));
            DateTime shippedDate = Convert.ToDateTime(order.ShippedDate);
            ViewBag.ShippedDate = (shippedDate.ToString("yyyy-MM-dd"));
            ViewBag.OrderDetails = orderdetails;
            return View();
        }

        /// <summary>
        /// 修改訂單
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoUpdate(Models.Employee order) {
            Models.EmployeeService orderService = new Models.EmployeeService();
            orderService.UpdateOrderById(order);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 刪除訂單
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DoDelete(string OrderID)
        {
            Models.EmployeeService orderService = new Models.EmployeeService();
            orderService.DeleteOrderById(OrderID);
            return RedirectToAction("Index");
        }
        */
    }
}