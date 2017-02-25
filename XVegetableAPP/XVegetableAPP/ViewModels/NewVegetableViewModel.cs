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
    public class NewVegetableViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private string descrpition;
        private decimal price;
        private bool isRunning; 
        private bool isEnabled;
        private ApiService apiService; 
        private DialogService dialogService; 
        private NavigationService navigationService;


        #endregion

        #region Commands

        #endregion

        #region Constructors
        public NewVegetableViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
            IsEnabled = true;
        }


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        public ICommand NewVegetableCommand { get { return new RelayCommand(NewVegetable); } }

        private async void NewVegetable()
        {
            if (string.IsNullOrEmpty(Descrpition))
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

            var newVegetable = new Vegetable
            {
                Description = Descrpition,
                Price = Price,
            };

            var response = await apiService.Post("http://vegetableapi.azurewebsites.net", "/api", "/Vegetables", newVegetable);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            Descrpition = string.Empty;
            Price = 0;
            await navigationService.Back();

        }


        #endregion

        #region Properties
        public string Descrpition
        {
            set
            {
                if (descrpition != value)
                {
                    descrpition = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Descrpition"));
                }
            }
            get
            {
                return descrpition;
            }
        }
        public decimal Price
        {
            set
            {
                if (price != value)
                {
                    price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                }
            }
            get
            {
                return price;
            }
        }
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
