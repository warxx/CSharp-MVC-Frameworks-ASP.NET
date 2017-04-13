using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Filters
{
    public class TimerAttribute : ActionFilterAttribute
    {
        private Stopwatch timer = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            var elapsedTime = timer.Elapsed;
            timer.Reset();

            var time = DateTime.Now;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;           

            var timerMsg 
                = $"{time} – {controllerName}.{actionName} - {elapsedTime}{Environment.NewLine}";

            File.AppendAllText("C:\\Users\\c0dyy_000\\Desktop\\timer.txt", timerMsg);
        }
    }
}