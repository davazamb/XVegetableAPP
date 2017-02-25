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
        private DialogService dialogService;

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
            //Singleton
            instance = this;

            //Services
            apiService = new ApiService();
            navigationService = new NavigationService();
            dialogService = new DialogService();

            //View Models
            Vegetables = new ObservableCollection<VegetableItemViewModel>();

            //Load Data
            LoadVegetables();
        }  

        #endregion

        #region Methods
        private async void LoadVegetables()
        {
            var response = await apiService.Get<Vegetable>("http://vegetableapi.azurewebsites.net", "/api", "/Vegetables");
            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }
            ReloadVegetables((List<Vegetable>)response.Result);
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
        public NewVegetableViewModel NewVegetable { get; set; }
        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion

    }
}
