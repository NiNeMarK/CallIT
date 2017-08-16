using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallIT.Web.Models
{
    public class staffModel
    {
        public int id { get; set; }
        public string staffCode { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}