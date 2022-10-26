namespace APICapstoneProject.Models
{
    public class MailRequest
    {


        public string Email { get; set; }
        public string Subject { get; set; }  //false-default-OrderDetail

        public  string Body { get; set; }

        

        //public string FurnitureNeeded { get; set; }
        //public string EquipmentNeeded { get; set; }
        //public string ShippingAddress { get; set; }

        public string DeliveryDate { get; set; }

        //public string ToEmail { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        //public List<IFormFile> Attachments { get; set; }

    }
}
