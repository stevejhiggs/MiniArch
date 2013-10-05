using System.Collections.Generic;
using System;

namespace MiniArch.ViewModels
{
	public class HomeIndexListCollectionViewModel
	{
		public IEnumerable<ToDoList> Items { get; internal set; }

		public class ToDoList
		{
			public string Name { get; internal set; }
			public IEnumerable<ToDoListItem> TodoListItems { get; internal set; }
		}

		public class ToDoListItem
		{
			public string Name { get; internal set; }
			public string Content { get; internal set; }

		}
	}
}