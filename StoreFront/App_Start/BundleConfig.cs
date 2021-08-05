using System.Web.Optimization;

namespace StoreFront
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/js/custom.js",
                "~/Scripts/js/owl.js",
                "~/Scripts/js/slick.js",
                "~/Scripts/js/isotope.js",
                "~/Scripts/js/accordions.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/css/fontawesome.css",
                      "~/Content/css/templatemo-sixteen.css",
                      "~/Content/css/owl.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/PagedList.css",
                      "~/Content/css/Style.css",
                      "~/Content/css/Site.css"));
        }
    }
}
