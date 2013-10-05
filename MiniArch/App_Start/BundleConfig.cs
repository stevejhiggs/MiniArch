using System.Web;
using System.Web.Optimization;

namespace MiniArch
{
	internal class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		internal static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
		}
	}
}