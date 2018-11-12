using System.Web.Mvc;

namespace bsuc.Areas.Index
{
    public class IndexAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Index";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Index_default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "bsuc.Areas.Index.Controllers" }
            );
        }
    }
}
