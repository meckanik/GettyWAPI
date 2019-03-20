using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GettyWAPI.Attributes
{
    /*
     https://github.com/stefanprodan/WebApiThrottle
     */

    public class ThrottleAttribute : ActionFilterAttribute
    {
        private int _APIRATEQUOTA = 60;
        private int _API_RATEQUOTA = 60;
        private int _API_BLOCKDURATION = 5; 

        private readonly object syncLock = new object();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }
    }
}