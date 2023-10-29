using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class UserViewModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public bool MaritalStatus { get; set; }

    }
    
}