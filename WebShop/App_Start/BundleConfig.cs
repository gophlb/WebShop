using System.Web;
using System.Web.Optimization;

namespace WebShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/modernizr-*",
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/respond.js",
                            "~/Scripts/alertify/alertify.min.js",
                            "~/Scripts/site/site.js"
                        ));

            

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
