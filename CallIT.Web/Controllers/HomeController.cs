using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CallIT.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.machineName = Environment.MachineName;
            ViewBag.machineName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();
            string strAddress = "";
            foreach (var i in addresses)
            {
                strAddress += i.ToString();
            }
            //ViewBag.machineIP = addresses[0].ToString();
            ViewBag.machineIP = strAddress;
            return View();
        }


    }
}