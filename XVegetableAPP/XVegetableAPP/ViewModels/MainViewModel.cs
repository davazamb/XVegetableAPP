using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XVegetableAPP.Models;
using XVegetableAPP.Services;

namespace XVegetableAPP.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private ApiService apiService;
        private NavigationService navigationService;

        #endregion

        #region Commands
        public ICommand AddVegetableCommand { get { return new RelayCommand(AddVegetable); } }

        private async void AddVegetable()
        {
            await navigationService.Navigate("NewVegetablePage");
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            apiService = new ApiService();
            Vegetables = new ObservableCollection<VegetableItemViewModel>();
            navigationService = new NavigationService();
            LoadVegetables();
        }  

        #endregion

        #region Methods
        private async void LoadVegetables()
        {
            var vegetables = await apiService.Get<Vegetable>("http://vegetableapi.azurewebsites.net", "/api", "/Vegetables");
            ReloadVegetables(vegetables);
        }

        private void ReloadVegetables(List<Vegetable> vegetables)
        {
            Vegetables.Clear();
            foreach (var vegetable in vegetables)
            {
                Vegetables.Add(new VegetableItemViewModel
                {
                    Description = vegetable.Description,
                    VegetableId = vegetable.VegetableId,
                    Price = vegetable.Price,
                });
            }
        }

        #endregion

        #region Properties
        public ObservableCollection<VegetableItemViewModel> Vegetables { get; set; }

        #endregion
    }
}
