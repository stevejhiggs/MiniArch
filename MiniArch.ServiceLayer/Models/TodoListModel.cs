using System;
using System.Collections.Generic;

namespace MiniArch.ServiceLayer.Models
{
	public class TodoListModel
	{
		public int? Id { get; internal set; }
		public string Name { get; set; }

		public IList<TodoListItemModel> Items { get; internal set; }

		public TodoListModel()
		{
			Items = new List<TodoListItemModel>();
		}
	}
}
