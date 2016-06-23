using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace WebApplication1.Models
{
    public class Employee
    {
        /// <summary>
        /// 員工ID
        /// </summary>
        [DisplayName("編號")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        [DisplayName("職稱")]
        public string Job { get; set; }

        /// <summary>
        /// 任職日期
        /// </summary>
        [DisplayName("任職日期")]
        public DateTime? WorkingDate { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [DisplayName("性別")]
        public string Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DisplayName("生日")]
        public DateTime? BirthdayDate { get; set; }
    }
}
