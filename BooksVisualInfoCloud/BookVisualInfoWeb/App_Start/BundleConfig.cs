using System.Web;
using System.Web.Optimization;

namespace BookVisualInfoWeb
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/Scripts/main").Include(
						"~/Scripts/main.js"));
			bundles.Add(new ScriptBundle("~/Scripts/libs").Include(
						"~/Scripts/libs/jquery.js",
						 "~/Scripts/libs/underscore.js",
						"~/Scripts/libs/sigma.js",
						"~/Scripts/libs/sigma.forceatlas2.js",
						"~/Scripts/libs/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/Content/css/main").Include(
						"~/Content/css/main.css"));
			bundles.Add(new ScriptBundle("~/Content/css/bootstrap").Include(
					"~/Scripts/bootstrap.min.css"));

		}
	}
}