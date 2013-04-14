using System.Web;
using System.Web.Optimization;

namespace HackFive.BookVisualInfoWeb
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{

			bundles.Add(new ScriptBundle("~/Scripts/libs").Include(
						
						"~/Scripts/libs/underscore.js",
						"~/Scripts/libs/knockout.js",
						"~/Scripts/libs/modernizr-2.6.2.min.js",
						"~/Scripts/libs/sigma.min.js",
						"~/Scripts/libs/sigma.forceatlas2.js",
						"~/Scripts/libs/jquery-1.9.1.min.js"));
						//"~/Scripts/libs/bootstrap/js/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/Scripts/main").Include(
						"~/Scripts/global.js",
						"~/Scripts/rest.js",
						"~/Scripts/graph.js",
						"~/Scripts/main.js",
						"~/Scripts/plugins.js"));

			bundles.Add(new ScriptBundle("~/Content/css").Include(
						"~/Content/css/main.css",
						"~/Content/css/normalize.css",
						"~/Content/css/bootstrap-responsive.min.csss"));
			//bundles.Add(new ScriptBundle("~/Script/libs/bootstrap/css").Include(
			//        "~/Scripts/libs/bootstrap/css/bootstrap.min.css"));

		}
	}
}
