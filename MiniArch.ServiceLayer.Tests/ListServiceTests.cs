using MiniArch.Persistance;
using MiniArch.ServiceLayer.Models;

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MiniArch.ServiceLayer.Tests
{
	[TestFixture]
	public class ListServiceTests
	{
		[TestFixtureSetUp]
		public void Setup()
		{
			MiniArch.ServiceLayer.AutoMapConfig.RegisterMappings();
		}

		[Test]
		public void CreateToDoList_Should_Create_ToDoList()
		{
			var connection = Effort.DbConnectionFactory.CreateTransient();
			using (var ctx = new MiniArchDatabaseContext(connection))
			{
				//write the list
				var service = new ListService(ctx);
				service.CreateToDoList(new TodoListModel()
				{
					Name = "test list"
				});

				//get the list

				var todoLists = ctx.TodoLists.ToList();
				Assert.AreEqual(todoLists.Count, 1);
				Assert.AreEqual(todoLists[0].Name, "test list");

			}
		}

		[Test]
		public void GetAllBlogs_GetAllListsWithItems_Should_Return_Enumerable_TodoLists()
		{
			var listData = new List<TodoList>
			{
				new TodoList { Name = "BBB", Id = 1 },
				new TodoList { Name = "ZZZ", Id = 2 },
				new TodoList { Name = "AAA", Id = 3 },
			};

			var listItemData = new List<TodoListItem>
			{
				new TodoListItem { Id = 1, Name = "testItem", Content = "test content"}
			};

			var connection = Effort.DbConnectionFactory.CreateTransient();
			using (var ctx = new MiniArchDatabaseContext(connection))
			{
				ctx.TodoLists.AddRange(listData);
				ctx.TodoListItems.AddRange(listItemData);
				ctx.SaveChanges();

				var service = new ListService(ctx);
				var todoLists = new List<TodoListModel>(service.GetAllListsWithItems());

				Assert.AreEqual(3, todoLists.Count);
				Assert.AreEqual("BBB", todoLists[0].Name);
				Assert.AreEqual("ZZZ", todoLists[1].Name);
				Assert.AreEqual("AAA", todoLists[2].Name);
			}
	
		}
	}
}
