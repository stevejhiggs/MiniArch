using AutoMapper;

namespace MiniArch.ServiceLayer
{
	internal class AutoMapConfig
	{
		internal static void RegisterMappings()
		{
			Mapper.AssertConfigurationIsValid();
		}
	}
}
