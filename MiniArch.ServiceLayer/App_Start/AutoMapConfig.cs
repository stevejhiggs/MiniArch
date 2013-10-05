using AutoMapper;
using MiniArch.Persistance;
using MiniArch.ServiceLayer.Models;

namespace MiniArch.ServiceLayer
{
	internal class AutoMapConfig
	{
		internal static void RegisterMappings()
		{
			//map our models to ef's dto's and vice versa
			Mapper.CreateMap<TodoListItemModel, TodoListItem>()
				.ForMember(dest => dest.ListId, opt => opt.Ignore())
				.ForMember(dest => dest.TodoList, opt => opt.Ignore())
					.ReverseMap()
						.ForSourceMember(src => src.ListId, opt => opt.Ignore())
						.ForSourceMember(src => src.TodoList, opt => opt.Ignore());

			Mapper.CreateMap<TodoListModel, TodoList>()
				.ReverseMap();
				

			Mapper.AssertConfigurationIsValid();
		}
	}
}
