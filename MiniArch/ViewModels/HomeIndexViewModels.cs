using System;
using System.Collections.Generic;

namespace MiniArch.ViewModels
{
	public class HomeIndexListCollectionViewModel
	{
		public List<HomeIndexListViewModel> Items { get;  private set; }

		public HomeIndexListCollectionViewModel()
		{
			Items = new List<HomeIndexListViewModel>();
		}
	}

	public class HomeIndexListViewModel
	{
		public string Name { get; set; }
		public List<HomeIndexListItemViewModel> Items { get; private set; }

		public HomeIndexListViewModel()
		{
			Items = new List<HomeIndexListItemViewModel>();
		}
	}

	public class HomeIndexListItemViewModel 
	{
		public string Name { get; set; }
		public string Content { get; set; }

	}
}