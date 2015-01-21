using System.Collections.Generic;
using Domain.Entities;

namespace Presentation.Web.Models
{
    public class HomeIndexViewModel
    {
        public int Total { get; set; }
        public IEnumerable<Account> Accounts { get; set; }  
    }
}