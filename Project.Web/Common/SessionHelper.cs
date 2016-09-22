using System.Web;
using System.Web.Mvc;

namespace Project.Web.Common
{
    public class SessionHelper
    {
        public string CurrentCulture
        {
            get
            {
                if (HttpContext.Current.Session["CurrentCulture"] == null)
                {
                    HttpContext.Current.Session["CurrentCulture"] = "en-US";
                }
                return (string)HttpContext.Current.Session["CurrentCulture"];
            }
            set
            {
                HttpContext.Current.Session["CurrentCulture"] = value;
            }
        }

        public UserSession UserSession
        {
            get
            {
                if (HttpContext.Current.Session["UserSession"] == null)
                {
                    return null;
                }
                return (UserSession)HttpContext.Current.Session["UserSession"];
            }
            set
            {
                HttpContext.Current.Session["UserSession"] = value;
            }
        }
    }

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["UserSession"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class ValidateRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionHelper session = new SessionHelper();
            // check  sessions here
            if (session == null || session.UserSession == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }
            if (!(session.UserSession.Role == "SUPER" || session.UserSession.Role == Role))
            {
                filterContext.Result = new RedirectResult("~/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class ValidateParticipantRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionHelper session = new SessionHelper();
            // check  sessions here
            if (session == null || session.UserSession == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }
            if (!(session.UserSession.Role == "SUPER" || session.UserSession.Role == "ADMIN" || session.UserSession.Role == "EDITOR"))
            {
                filterContext.Result = new RedirectResult("~/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class ValidateUserRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionHelper session = new SessionHelper();
            // check  sessions here
            if (session == null || session.UserSession == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }
            if (!(session.UserSession.Role == "SUPER" || session.UserSession.Role == "ADMIN"))
            {
                filterContext.Result = new RedirectResult("~/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class ValidateReportRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionHelper session = new SessionHelper();
            // check  sessions here
            if (session == null || session.UserSession == null)
            {
                filterContext.Result = new RedirectResult("~/Account/LogOut");
                return;
            }
            if (!(session.UserSession.Role == "SUPER" || session.UserSession.Role == "ADMIN" || session.UserSession.Role == "EDITOR" || session.UserSession.Role == "REPORTER"))
            {
                filterContext.Result = new RedirectResult("~/");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}