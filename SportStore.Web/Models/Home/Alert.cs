using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Home
{
    public static class Alert
    {
        public static bool IsAlerted = false;
        public static string AlertType { get; set; }
        public static string Message { get; set; }

        public static void SetAlert(AlertStatus status, string message)
        {
            string alert = String.Empty;

            switch (status)
            { 
                case AlertStatus.Succes:
                    alert = "success";
                    break;
                case AlertStatus.Info:
                    alert = "info";
                    break;
                case AlertStatus.Warning:
                    alert = "warning";
                    break;
                case AlertStatus.Danger:
                    alert = "danger";
                    break;
            }

            AlertType = alert;
            Message = message;
            IsAlerted = true;
        }

        public static void ClearAlert()
        {
            AlertType = String.Empty;
            Message = String.Empty;
            IsAlerted = false;
        }
    }

    public enum AlertStatus
    {  
        Succes, Info, Warning, Danger
    }
}