using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public class UserAuthorizeAttribute : AuthorizeAttribute
        {
            //protected override bool AuthorizeCore(HttpContextBase httpContext)
            //{
            //    var authorized = base.AuthorizeCore(httpContext);
            //    if (!authorized)
            //    {
            //        return false;
            //    }

            //    var rd = httpContext.Request.RequestContext.RouteData;

            //    var id = rd.Values["id"];
            //    var userName = httpContext.User.Identity.Name;

            //Submission submission = unit.SubmissionRepository.GetByID(id);
            //Users user = unit.UserRepository.GetByUsername(userName);

            //return submission.UserID == user.UserID;
            // }
            // }
            //
            //[MyAuthorize]
            //public ActionResult Edit(int id)
            //{
            //    // Carry out method
            //}

            //public String ErrorMessage
            //{
            //    get { return TempData["ErrorMessage"] == null ? String.Empty : TempData["ErrorMessage"].ToString(); }
            //    set { TempData["ErrorMessage"] = value; }
            //}
        }
    }
}