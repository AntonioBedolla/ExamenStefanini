using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ExamenStefanini.Models;
using ExamenStefanini.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ExamenStefanini.ViewModels
{
	public class MainPageViewModel: BaseViewModel
	{
		private ObservableCollection<Applications> _items;

		public ObservableCollection<Applications> Items
		{
			get => _items;
			set => SetProperty(ref _items, value);
		}

		public Command NavigationCommand => new Command(NavigationToPopUp);


		private Applications _applications;

		public Applications Applications
		{
			get => _applications;
			set => SetProperty(ref _applications, value);
		}

		public Applications AppSelection { get; set; }


		public MainPageViewModel()
		{
			Items = new ObservableCollection<Applications>();
			LoadData();
		}

		public async void LoadData()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataApp.GetItemsAsync(true);
				foreach (var item in items)
				{
					Items.Add(item);

				}

                if (AppSelection.Price == "0.5" && Applications.Price == "Free")
                {
                    AppSelection.Price = "Free";
                }
            }
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

			finally
			{
				IsBusy = false;
			}
		}

		public  async void NavigationToPopUp()
		{
			if (AppSelection == null)
				return;

			if (AppSelection.Id==AppSelection.Id)
			{
				await App.Navigation.PushModalAsync(new AppDetailPage());


            }
        }

    }
}

