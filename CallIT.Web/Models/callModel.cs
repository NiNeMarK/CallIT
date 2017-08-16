using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallIT.Web.Models
{
    public class callModel
    {
        public int id { get; set; }
        public string machineName { get; set; }
        public string machineIP { get; set; }
        public string sendName { get; set; }
        public string sendTel { get; set; }
        public string sendText { get; set; }
        public Nullable<System.DateTime> sendDatetime { get; set; }
    }
}