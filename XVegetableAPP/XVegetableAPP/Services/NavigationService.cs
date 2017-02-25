using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XVegetableAPP.Pages;

namespace XVegetableAPP.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "NewVegetablePage":
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
