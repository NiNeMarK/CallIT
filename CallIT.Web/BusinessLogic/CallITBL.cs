using CallIT.Web.Data;
using CallIT.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CallIT.Web.BusinessLogic
{
    public class CallITBL
    {
        public MessageResult Save(callModel model)
        {
            MessageResult result = new MessageResult();
            try
            {
                using (CallITEntities db = new CallITEntities())
                {
                    call md = new call();
                    md.machineName = model.machineName;
                    md.machineIP = model.machineIP;
                    md.sendDatetime = model.sendDatetime;
                    md.sendName = model.sendName;
                    md.sendText = model.sendText;
                    md.sendTel = model.sendTel;


                    db.call.Add(md);
                    db.SaveChanges();

                    result.status = "success";
                }
            }
            catch (DbEntityValidationException exp)
            {
                foreach (var entityValidationErrors in exp.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}",
                          validationError.PropertyName, validationError.ErrorMessage);
                    }

                }

                result.status = "error";
            }

            return result;
        }
    }
}