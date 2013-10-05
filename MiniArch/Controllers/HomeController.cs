using MiniArch.ServiceLayer;
using MiniArch.ServiceLayer.Models;
using MiniArch.ViewModels;
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

			var listItems = ListService.GetAllListsWithItems();
		
			foreach(var list in listItems)
			{
				var listModel = new HomeIndexListViewModel() { Name = list.Name };
				foreach (var subItem in list.Items)
				{
					listModel.Items.Add(new HomeIndexListItemViewModel() 
										{
											Name = subItem.Name,
											Content = subItem.Content
										});
				}

				model.Items.Add(listModel);
			}
			
			return View(model);
		}

		public ActionResult Add()
		{
			var todoListModel = new TodoListModel();
			todoListModel.Name = "shopping list";
			todoListModel.Items.Add(new TodoListItemModel() 
									{
										Name = "chips",
										Content = "mmm chips"
									});
			ListService.CreateToDoList(todoListModel);
			return View();
		}

	}
}
