using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XVegetableAPP.Pages;
using XVegetableAPP.ViewModels;

namespace XVegetableAPP.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "NewVegetablePage":
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.NewVegetable = new NewVegetableViewModel();  
                    await App.Current.MainPage.Navigation.PushAsync(new NewVegetablePage());
                    break;
                default:
                    break;
            }
        }

        public async Task Back()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
