using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XVegetableAPP.Models;

namespace XVegetableAPP.ViewModels
{
    public class EditVegetableViewModel : Vegetable
    {
        #region Attributes   

        #endregion

        #region Commands

        #endregion

        #region Constructors   
        public EditVegetableViewModel(Vegetable vegetable)
        {
            Description = vegetable.Description;
            Price = vegetable.Price;
            VegetableId = vegetable.VegetableId;

        }    
        #endregion

        #region Methods

        #endregion

        #region Properties                                                 
                               
        #endregion
    }
}
