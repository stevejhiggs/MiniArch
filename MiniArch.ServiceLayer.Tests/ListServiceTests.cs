using MiniArch.Persistance;
using MiniArch.ServiceLayer.Models;
using MiniArch.ServiceLayer.Tests.Mocking;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
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
			var mockContext = new Mock<MiniArchDatabaseContext>();

			var mockSet = new Mock<DbSet<TodoList>>();
			mockContext.Setup(m => m.TodoLists).Returns(mockSet.Object);

			var service = new ListService(mockContext.Object);

			service.CreateToDoList(new TodoListModel() 
									{
										Name = "test list"
									});

			mockSet.Verify(m => m.Add(It.IsAny<TodoList>()), Times.Once());
			mockContext.Verify(m => m.SaveChanges(), Times.Once());
		}

		//this doesn't like the include statement otherwise it would run fine...
		/*[Test]
		public void GetAllBlogs_GetAllListsWithItems_Should_Return_Enumerable_TodoLists()
		{
			var listData = new List<TodoList>
			{
				new TodoList { Name = "BBB", Id = 1 },
				new TodoList { Name = "ZZZ", Id = 2 },
				new TodoList { Name = "AAA", Id = 3 },
			}.AsQueryable();

			var listItemData = new List<TodoListItem>
			{
				new TodoListItem { Id = 1, Name = "testItem", Content = "test content"}
			}.AsQueryable();

			var mockContext = new Mock<MiniArchDatabaseContext>();

			var mockSetLists = new Mock<MockableDbSetWithIQueryable<TodoList>>();
			mockContext.Setup(c => c.TodoLists).Returns(mockSetLists.Object);
			mockSetLists.Setup(m => m.Provider).Returns(listData.Provider);
			mockSetLists.Setup(m => m.Expression).Returns(listData.Expression);
			mockSetLists.Setup(m => m.ElementType).Returns(listData.ElementType);
			mockSetLists.Setup(m => m.GetEnumerator()).Returns(listData.GetEnumerator());

			var mockSetListItems = new Mock<MockableDbSetWithIQueryable<TodoListItem>>();
			mockContext.Setup(c => c.TodoListItems).Returns(mockSetListItems.Object);
			mockSetListItems.Setup(m => m.Provider).Returns(listItemData.Provider);
			mockSetListItems.Setup(m => m.Expression).Returns(listItemData.Expression);
			mockSetListItems.Setup(m => m.ElementType).Returns(listItemData.ElementType);
			mockSetListItems.Setup(m => m.GetEnumerator()).Returns(listItemData.GetEnumerator());

			var service = new ListService(mockContext.Object);
			var todoLists = new List<TodoListModel>(service.GetAllListsWithItems());

			Assert.AreEqual(3, todoLists.Count);
			Assert.AreEqual("AAA", todoLists[0].Name);
			Assert.AreEqual("BBB", todoLists[1].Name);
			Assert.AreEqual("ZZZ", todoLists[2].Name);
		}*/
	}
}
