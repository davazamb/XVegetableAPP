using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XVegetableAPP.Models;
using XVegetableAPP.Services;

namespace XVegetableAPP.ViewModels
{
    public class VegetableItemViewModel : Vegetable
    {
        #region Attributes
        private NavigationService navigationService;
        #endregion

        #region Commands

        #endregion

        #region Constructors
        public VegetableItemViewModel()
        {
            navigationService = new NavigationService();
        }
        #endregion

        #region Methods

        #endregion

        #region Properties
        public ICommand EditVegetableCommand { get { return new RelayCommand(EditVegetable); } }

        private async void EditVegetable()
        {
            await navigationService.EditVegetable(this);
        }
        #endregion

    }
}
