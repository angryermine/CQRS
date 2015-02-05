using System.Collections.Generic;
using Domain.Entities;

namespace Presentation.Web.Models
{
    public class HomeIndexViewModel
    {
        public int Total { get; set; }
        public int Today { get; set; }
        public int Month { get; set; }
        public IEnumerable<Account> Accounts { get; set; }  
    }
}