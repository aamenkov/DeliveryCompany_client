using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace DeliveryCompany_Wpf.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Коллекция заявок отделения
        /// </summary>
        public List<Application> ApplicationList { get; set; }
    }
}
