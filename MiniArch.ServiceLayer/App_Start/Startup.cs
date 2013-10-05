using System;

namespace MiniArch.ServiceLayer
{
	public class Startup
	{
		public static void RegisterStartupDependancies()
		{
			AutoMapConfig.RegisterMappings();
		}
	}
}
