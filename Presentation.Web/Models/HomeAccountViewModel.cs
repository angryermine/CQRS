using System;

namespace Presentation.Web.Models
{
    public class HomeAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}