using ApiScoreBoard.Resources.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiScoreBoard.Helpers.Filters
{
    public class AuditFilter : Attribute,IActionFilter
    {
        public AuditFilter()
        {
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            var model = actionContext.ActionArguments.FirstOrDefault(x => x.Value is IBase).Value as IBase;
            if (model == null) return continuation();
            if (model.CreatedBy != null)
            {
                //model.UpdatedBy = filterContext.HttpContext.User.Identity.GetUserId();
                model.UpdatedDate = DateTime.Now;

            }
            else
            {
                //model.CreatedBy = filterContext.HttpContext.User.Identity.GetUserId();
                model.CreatedDate = DateTime.Now;
            }

            return continuation();
        }

        public void OnActionExecuting(HttpActionContext filterContext)
        {
            var model = filterContext.ActionArguments.FirstOrDefault(x=>x.Value is IBase).Value as IBase;
            //model.UpdatedBy = filterContext.ActionContext.ControllerContext.RequestContext.Principal.Identity.GetUserId();
            //var model = filterContext.ActionParameters.FirstOrDefault(x => x.Value is IBase).Value as IBase;
            

        }

    }
}