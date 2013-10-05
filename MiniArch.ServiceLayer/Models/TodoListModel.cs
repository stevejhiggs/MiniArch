using System.Collections.Generic;

namespace MiniArch.ServiceLayer.Models
{
	public class TodoListModel
	{
		public int? Id { get; internal set; }
		public string Name { get; set; }

		public IList<TodoListItemModel> TodoListItems { get; internal set; }

		public TodoListModel()
		{
			TodoListItems = new List<TodoListItemModel>();
		}
	}
}
