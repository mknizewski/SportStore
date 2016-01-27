using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class EmployeeAlert
    {
        public string Alert { get; set; }
        public string Message { get; set; }

        public static EmployeeAlert SetAlert(EmployyeAlerts alert, string txt)
        {
            var model = new EmployeeAlert();

            switch(alert)
            {
                case EmployyeAlerts.Succes:
                    model.Alert = "alert-success";
                    break;
                case EmployyeAlerts.Danger:
                    model.Alert = "alert-danger";
                    break;
                case EmployyeAlerts.Info:
                    model.Alert = "alert-info";
                    break;
                case EmployyeAlerts.Warning:
                    model.Alert = "alert-warning";
                    break;
            }

            model.Message = txt;

            return model;
        }
    }

    public enum EmployyeAlerts
    {
        Succes, Danger, Warning, Info
    }
}