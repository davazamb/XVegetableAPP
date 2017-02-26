using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XVegetableAPP.Models;
using XVegetableAPP.Pages;
using XVegetableAPP.ViewModels;

namespace XVegetableAPP.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            var mainViewModel = MainViewModel.GetInstance();

            switch (pageName)
            {
                
                case "NewVegetablePage":
                    mainViewModel.NewVegetable = new NewVegetableViewModel();
                    await App.Current.MainPage.Navigation.PushAsync(new NewVegetablePage());
                    break; 
                default:
                    break;
            }
        }
        public async Task EditVegetable(Vegetable vegetable)
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.EditVegetable = new EditVegetableViewModel(vegetable);
            await App.Current.MainPage.Navigation.PushAsync(new EditVegetablePage());
        }


        public async Task Back()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
