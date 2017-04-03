using System;
using System.IO;
using System.Web.Mvc;
using CarDealerApp.Security;

namespace CarDealerApp.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var time = DateTime.Now;
            var IpAdress = filterContext.HttpContext.Request.UserHostAddress;
            
            var sessionCookie = filterContext.HttpContext.Request.Cookies.Get("sessionId");
            string username = "Anonymous";
            if (sessionCookie != null && AuthenticationManager.IsAuthenticated(sessionCookie.Value))
            {
                username = AuthenticationManager.GetUser(sessionCookie.Value).Username;
            }
            
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            var exception = filterContext.Exception;
            var logMessage = "";

            if (exception != null)
            {
                logMessage =
                    $"[!] {time} – {IpAdress} – {username} – {controllerName}.{actionName} - {exception.GetType().Name} – {exception.Message}{Environment.NewLine}";
            }
            else
            {
                logMessage = $"{time} – {IpAdress} – {username} – {controllerName}.{actionName}{Environment.NewLine}";
            }

            File.AppendAllText("C:\\Users\\c0dyy_000\\Desktop\\log.txt", logMessage);
        }
    }
}