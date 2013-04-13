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
						"~/Scripts/libs/jquery.js",
						 "~/Scripts/libs/underscore.js",
						  "~/Scripts/libs/knockout.js",
						"~/Scripts/libs/sigma.js",
						"~/Scripts/libs/sigma.forceatlas2.js",
						"~/Scripts/libs/bootstrap/js/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/Scripts/main").Include(
					"~/Scripts/main.js",
					"~/Scripts/rest.js",
					"~/Scripts/graph.js"));

			bundles.Add(new ScriptBundle("~/Content/css/main").Include(
						"~/Content/css/main.css"));
			bundles.Add(new ScriptBundle("~/Script/libs/bootstrap/css").Include(
					"~/Scripts/libs/bootstrap/css/bootstrap.min.css"));

		}
	}
}