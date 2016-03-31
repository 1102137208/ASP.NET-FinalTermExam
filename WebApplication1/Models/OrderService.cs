using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class OrderService
    {
        private List<Order> MapEmployeeDataToList(DataTable dataTable)
        {
            List<Models.Order> result = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Order
                {
                    EmployeeID = (int)row["EmployeeID"],
                    EmployeeName = row["EmployeeName"].ToString()
                });
            }
            return result;
        }
        private List<Order> MapShipperDataToList(DataTable dataTable)
        {
            List<Models.Order> result = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Order
                {
                    ShipperID = (int)row["ShipperID"],
                    ShipperName = row["ShipperName"].ToString()
                });
            }
            return result;
        }
        private List<Order> MapOrderDataToList(DataTable dataTable)
        {
            List<Models.Order> result = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Order
                {
                    OrderID = (int)row["OrderID"],
                    CustomerName = row["CustomerName"].ToString(),
                    OrderDate = (DateTime)row["OrderDate"],
                    ShippedDate = row["ShippedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ShippedDate"]
                });
            }
            return result;
        }
        /// <summary>
        /// 連結資料庫
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        }
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order"></param>
        public void InsertOrder(Models.Order order)
        {
            //todo
        }
        /// <summary>
        /// 依照Id 取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrderById(Models.Order order)
        {
            DataTable dataTable = new DataTable();
            string sql = @"Select OrderID, CompanyName AS CustomerName,  OrderDate, ShippedDate
                            From Sales.Orders O join Sales.Customers C on O.CustomerID = C.CustomerID 
                            Where (OrderID = @OrderID OR @OrderID = 0)
                              AND (CompanyName = @CompanyName OR @CompanyName IS NULL)
                              AND (EmployeeID = @EmployeeID OR @EmployeeID = 0)
                              AND (ShipperID = @ShipperID OR @ShipperID = 0)
                              AND (OrderDate = @OrderDate OR @OrderDate IS NULL)
                              AND (ShippedDate = @ShippedDate OR @ShippedDate IS NULL)
                              AND (RequiredDate = @RequiredDate OR @RequiredDate IS NULL)";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@OrderID", order.OrderID));
                cmd.Parameters.Add(new SqlParameter("@CompanyName", order.CustomerName == null ? (object)DBNull.Value : order.CustomerName));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", order.EmployeeID));
                cmd.Parameters.Add(new SqlParameter("@ShipperID", order.ShipperID));
                cmd.Parameters.Add(new SqlParameter("@OrderDate", order.OrderDate == null ? (object)DBNull.Value : order.OrderDate));
                cmd.Parameters.Add(new SqlParameter("@ShippedDate", order.ShippedDate == null ? (object)DBNull.Value : order.ShippedDate));
                cmd.Parameters.Add(new SqlParameter("@RequiredDate", order.RequiredDate == null ? (object)DBNull.Value : order.RequiredDate));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dataTable);
                conn.Close();
            }
            return this.MapOrderDataToList(dataTable);
        }

        

        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        /* public List<Models.Order> GetOrderByCondtioin()
         {
             //todo
             List<Models.Order> result = new List<Order>();
             result.Add(new Order() { CustId = "001", CustName = "叡揚資訊", EmpId = 1, EmpName = "王小明", Orderdate = DateTime.Parse("2015/11/08") });
             result.Add(new Order() { CustId = "002", CustName = "網軟資訊", EmpId = 2, EmpName = "李小華", Orderdate = DateTime.Parse("2015/11/01") });
             return result;
         }*/
        /// <summary>
        /// 刪除訂單
        /// </summary>
        public void DeleteOrderById(string orderId)
        {
            //todo
        }
        /// <summary>
        /// 更新訂單
        /// </summary>
        public void UpdateOrder(Models.Order order)
        {
            //todo
        }

        /// <summary>
        /// 取得員工資料
        /// </summary>
        public List<Models.Order> GetEmployeeData()
        {
            DataTable dataTable = new DataTable();
            string sql = @"Select EmployeeID, FirstName + ' ' + LastName As EmployeeName
                         From HR.Employees";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dataTable);
                conn.Close();
            }
                return this.MapEmployeeDataToList(dataTable);
        }

        /// <summary>
        /// 取得供應商資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetShipperData()
        {
            DataTable dataTable = new DataTable();
            string sql = @"Select ShipperID, CompanyName As ShipperName
                           From Sales.Shippers";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dataTable);
                conn.Close();
            }
            return this.MapShipperDataToList(dataTable);
        }

        
    }
}
