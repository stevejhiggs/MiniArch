using AutoMapper;
using MiniArch.Persistance;
using MiniArch.ServiceLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MiniArch.ServiceLayer
{
	public class ListService
	{
		private MiniArchDatabaseContext dbContext;

		public ListService() : this(DbContextHelper.GetLightweightDbContext<MiniArchDatabaseContext>())
		{
		} 

		internal ListService(MiniArchDatabaseContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IEnumerable<TodoListModel> GetAllListsWithItems()
		{
			var listsDto = dbContext.TodoLists.Include(b => b.TodoListItems).ToList();
			var model = Mapper.Map<List<TodoListModel>>(listsDto);
			return model;
		}

		public void CreateToDoList(TodoListModel todoList)
		{
			var listDto = Mapper.Map<TodoList>(todoList);
			dbContext.TodoLists.Add(listDto);
			dbContext.SaveChanges();

			//remap back to pick up id's etc..
			Mapper.Map(listDto, todoList);
		}
	}
}
