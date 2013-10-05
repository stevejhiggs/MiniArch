using AutoMapper;
using MiniArch.ServiceLayer;
using MiniArch.ServiceLayer.Models;
using MiniArch.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MiniArch.Controllers
{
	public class HomeController : Controller
	{
		private ListService ListService;

		internal HomeController(ListService listService)
		{
			ListService = listService;
		}

		public HomeController() : this(new ListService())
		{

		}

		//
		// GET: /Home/

		public ActionResult Index()
		{
			var model = new HomeIndexListCollectionViewModel();
			model.Items = Mapper.Map<IEnumerable<HomeIndexListCollectionViewModel.ToDoList>>(ListService.GetAllListsWithItems());
		
	

			
			return View(model);
		}

		public ActionResult Add()
		{
			var todoListModel = new TodoListModel();
			todoListModel.Name = "shopping list";
			todoListModel.TodoListItems.Add(new TodoListItemModel() 
									{
										Name = "chips",
										Content = "mmm chips"
									});
			ListService.CreateToDoList(todoListModel);
			return View();
		}

	}
}
