using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APICapstoneProject.Models
{

    public class OrderDetail
    {

    
        public string Uid { get; set; }
        public string Email { get; set; }
        public string FurnitureNeeded { get; set; }
        public string EquipmentNeeded { get; set; }
        public string ShippingAddress { get; set; }

        public string DeliveryDate { get; set; }
      



    }
}
