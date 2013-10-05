using AutoMapper;
using MiniArch.ServiceLayer.Models;
using MiniArch.ViewModels;

namespace MiniArch
{
	internal class AutoMapConfig
	{
		internal static void RegisterMappings()
		{
			Mapper.CreateMap<TodoListItemModel, HomeIndexListCollectionViewModel.ToDoListItem>();
			Mapper.CreateMap<TodoListModel, HomeIndexListCollectionViewModel.ToDoList>();

			Mapper.AssertConfigurationIsValid();
		}
	}
}
