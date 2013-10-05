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

		public IList<TodoListModel> GetAllListsWithItems()
		{
			var model = new List<TodoListModel>();
			var listsDto = dbContext.TodoLists.Include(b => b.TodoListItems).ToList();

			foreach(var listDto in listsDto)
			{
				var listModel = new TodoListModel();
				listModel.Name = listDto.Name;
				listModel.Id = listDto.Id;

				foreach(var listItemDto in listDto.TodoListItems)
				{
					var listItemModel = new TodoListItemModel();
					listItemModel.Id = listItemDto.Id;
					listItemModel.Name = listItemDto.Name;
					listItemModel.Content = listItemDto.Content;
					listModel.Items.Add(listItemModel);
				}

				model.Add(listModel);
			}
			return model;
		}

		public void CreateToDoList(TodoListModel todoList)
		{
			var listDto = new TodoList();
			listDto.Name = todoList.Name;
			foreach(var item in todoList.Items)
			{
				var itemDto = new TodoListItem();
				itemDto.Name = item.Name;
				itemDto.Content = item.Content;
				listDto.TodoListItems.Add(itemDto);
			}

			dbContext.TodoLists.Add(listDto);
			dbContext.SaveChanges();
		}
	}
}
