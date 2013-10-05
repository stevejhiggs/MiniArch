using AutoMapper;
using MiniArch.ServiceLayer.Models;

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
