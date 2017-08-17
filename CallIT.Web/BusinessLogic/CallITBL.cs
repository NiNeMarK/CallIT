using CallIT.Web.Data;
using CallIT.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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

        public void testConnect()
        {
        string svh_sql3 = ConfigurationManager.ConnectionStrings["svh-sql3"].ToString();
        SqlConnection sql3 = new SqlConnection(svh_sql3);

            string XSQL2;
            XSQL2 = "SELECT *  FROM VIEW_Ayudha";

            if (sql3.State != ConnectionState.Open)
            {
                sql3.Open();
            }

            SqlCommand SCM3 = new SqlCommand(XSQL2, sql3);
            string XINDES;
            try
            {
                XINDES = SCM3.ExecuteScalar().ToString();
                try
                {
                    //dts11.Tables[0].Rows[XCNT]["PHCFR_DESC1"] = XINDES;
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }

        }
    }
}