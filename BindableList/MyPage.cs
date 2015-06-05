using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace BindableList
{
	public class MyPage : ContentPage
	{
		List<Users> lst = new List<Users> ();
		public MyPage ()
		{
			lst = new List<Users> ();
			lst.Add (new Users{ IdUser = 1, Name = "juna", LastName = "cuerdas" });
			lst.Add (new Users{ IdUser = 2, Name = "pepe", LastName = "el toro" });
			lst.Add (new Users{ IdUser = 3, Name = "pancho", LastName = "lopez" });

			ListView lstV = new ListView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			lstV.ItemTemplate = new DataTemplate(typeof(ImageCell));
			lstV.ItemTemplate.SetBinding(ImageCell.TextProperty, "Name");
			lstV.ItemTemplate.SetBinding(ImageCell.DetailProperty, "LastName");
			lstV.ItemsSource = lst;

			lstV.ItemTapped += (sender, e) => {
				Users usr = lst.Where(x=>x.IdUser==((Users)e.Item).IdUser).FirstOrDefault();
			};

			Content = new StackLayout { 
				Children = {
					lstV
				}
			};
		}
	}
}


