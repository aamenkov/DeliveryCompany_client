using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCompany_Wpf.Models
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public string ReceivingAddress { get; set; }
        public string ReceivingTown { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryTown { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Volume
        {
            get { return (double)Length * Width * Height * 0.000001; }
            private set { ; }
        }

        public DateTime ReceivingDateTime;
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public int DepartmentId { get; set; }
    }
}
