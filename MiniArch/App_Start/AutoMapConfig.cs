using AutoMapper;

namespace MiniArch
{
	internal class AutoMapConfig
	{
		internal static void RegisterMappings()
		{
			Mapper.AssertConfigurationIsValid();
		}
	}
}
