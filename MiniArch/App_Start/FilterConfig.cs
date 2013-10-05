using System.Web;
using System.Web.Mvc;

namespace MiniArch
{
	internal class FilterConfig
	{
		internal static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}