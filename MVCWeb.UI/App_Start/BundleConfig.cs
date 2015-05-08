using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;
using Microsoft.Data.Edm.Csdl;

namespace MVCWeb.UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            var scriptBundle = new ScriptBundle("~/bundles/scripts")
               .Include(
                   "~/Scripts/jquery-{version}.js",
                   "~/Scripts/jquery.validate.js",
                   "~/Scripts/jquery.validate.globalize.js",
                   "~/Scripts/jquery.validate.unobtrusive.js",
                   "~/Scripts/jquery.form.js",
                   "~/Scripts/jquery.cookie.js",
                   "~/Scripts/jquery-ui-{version}.js",
                   "~/Scripts/modernizr-*",
                   "~/Scripts/bootstrap.js",
                   "~/Scripts/application.js",
                   "~/Scripts/form.js",
                   "~/Scripts/dialog.js");

            scriptBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(scriptBundle);
        }

        public class AsIsBundleOrderer : IBundleOrderer
        {
            public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
            {
                return files;
            }
        }
    }
}