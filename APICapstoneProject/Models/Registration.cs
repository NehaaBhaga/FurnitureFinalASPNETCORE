using System.ComponentModel.DataAnnotations;

namespace APICapstoneProject.Models
{
    public class Registration
    {
        [Key]
        public string Uid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string Role { get; set; }

    

    }
}
