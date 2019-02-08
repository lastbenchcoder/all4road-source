using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DDWBlogger.Project.Source.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle scriptBndl = new ScriptBundle("~/bundles/javascriptfiles");
            scriptBndl.Include(
                "~/content/frontend/js/jquery-1.7.1.min.js",
                "~/content/frontend/js/jquery.backstretch.js",
                "~/content/frontend/js/jquery.nivo.slider.pack.js",
                "~/content/frontend/js/jquery.prettyPhoto.js",
                "~/content/frontend/js/jquery.sticky.js",
                "~/content/frontend/js/jquery.carouFredSel-5.6.2.js",
                "~/content/frontend/js/jquery.tweet.js",
                 "~/content/frontend/js/custom.js"
              );

            bundles.Add(scriptBndl);

            BundleTable.EnableOptimizations = true;
        }
    }
}
