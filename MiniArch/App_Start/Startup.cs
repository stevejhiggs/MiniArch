﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MiniArch
{
	internal class Startup
	{
		internal static void RegisterStartupDependancies()
		{
			MiniArch.ServiceLayer.Startup.RegisterStartupDependancies();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AutoMapConfig.RegisterMappings();
		}
	}
}