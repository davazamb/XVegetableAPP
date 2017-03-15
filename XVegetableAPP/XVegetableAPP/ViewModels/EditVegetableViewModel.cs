using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XVegetableAPP.Models;
using XVegetableAPP.Services;

namespace XVegetableAPP.ViewModels
{
    public class EditVegetableViewModel : Vegetable, INotifyPropertyChanged
    {
        #region Attributes   
        private bool isRunning;
        private bool isEnabled;
        private DialogService dialogService;   
        private ApiService apiService;
        private NavigationService navigationService;


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors   
        public EditVegetableViewModel(Vegetable vegetable)
        {
            dialogService = new DialogService();
            apiService = new ApiService();
            navigationService = new NavigationService();

            Description = vegetable.Description;
            Price = vegetable.Price;
            VegetableId = vegetable.VegetableId;

            IsEnabled = true;

        }
        #endregion

        #region Methods
        public ICommand SaveVegetableCommand { get { return new RelayCommand(SaveVegetable); } }

        private async void SaveVegetable()
        {
            if (string.IsNullOrEmpty(Description))
            {
                await dialogService.ShowMessage("Error", "You must enter a description");
                return;
            }

            if (Price <= 0)
            {
                await dialogService.ShowMessage("Error", "The price must be greather than zero");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var response = await apiService.Put("http://vegetableapi.azurewebsites.net", "/api", "/Vegetables", this);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            await navigationService.Back();
        }

        public ICommand DeleteVegetableCommand { get { return new RelayCommand(DeleteVegetable); } }

        private async void DeleteVegetable()
        {
            var answer = await dialogService.ShowConfirm("Confirm", "Are you sure to delete this record?");
            if (!answer)
            {
                return;
            }
               
            IsRunning = true;
            IsEnabled = false;   

            var response = await apiService.Delete("http://vegetableapi.azurewebsites.net", "/api", "/Vegetables", this); 

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }
                            
            await navigationService.Back();

        }
        #endregion

        #region Properties                                                 


        public bool IsRunning
        {
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
            get
            {
                return isRunning;
            }
        }
        public bool IsEnabled
        {
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
                }
            }
            get
            {
                return isEnabled;
            }
        }
        #endregion
    }
}
