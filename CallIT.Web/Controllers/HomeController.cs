using CallIT.Web.BusinessLogic;
using CallIT.Web.Models;
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
            int j = 1;
            foreach (var i in addresses)
            {
                strAddress += i.ToString() + (j < addresses.Length ? "," : "");

                j++;
            }
            //ViewBag.machineIP = addresses[0].ToString();
            ViewBag.machineIP = strAddress;

            //new CallITBL().testConnect();
            ViewBag.Message = new MessageResult();

            
            return View();
        }

        [HttpPost]
        public ActionResult Index(callModel model)
        {
            ViewBag.machineName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();
            string strAddress = "";
            int j = 1;
            foreach (var i in addresses)
            {
                strAddress += i.ToString() + (j < addresses.Length ? "," : "");

                j++;
            }
            //ViewBag.machineIP = addresses[0].ToString();
            ViewBag.machineIP = strAddress;

            model.sendDatetime = DateTime.Now;

            ViewBag.Message = new CallITBL().Save(model);

            callModel model1 = new callModel();

            return View();
        }


    }
}