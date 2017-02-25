using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XVegetableAPP.ViewModels;

namespace XVegetableAPP.Pages
{
    public partial class VegetablesPage : ContentPage
    {
        public VegetablesPage()
        {
            InitializeComponent();
            var mainViewModel = MainViewModel.GetInstance();
            base.Appearing += (object sender, EventArgs e) =>
            {
                mainViewModel.RefreshVegetablesCommand.Execute(this);
            };

        }
    }
}
