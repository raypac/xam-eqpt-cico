using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xam_eqpt_cico.Models;
using xam_eqpt_cico.Services;
using xam_eqpt_cico.Utilities;
using xam_eqpt_cico.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static xam_eqpt_cico.Utilities.StaticDefinition;

namespace xam_eqpt_cico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EqptListPage : ContentPage
    {
        EqptListViewModel viewModel;

        public EqptListPage()
        {
            InitializeComponent();

            Title = "Equiptment List";

            BindingContext = viewModel = new EqptListViewModel();

        }

        public EqptListPage(int scanAction = 0)
        {
            InitializeComponent();

            Title = "Equiptment List";

            BindingContext = viewModel = new EqptListViewModel();

            switch (scanAction)
            {
                case (int)EquiptmentScanAction.CheckIn:
                    Task.Run(async () => { await Navigation.PushAsync(new EqptScanPage((int)EquiptmentScanAction.CheckIn)); });
                    break;
                case (int)EquiptmentScanAction.CheckOut:
                    Task.Run(async () => { await Navigation.PushAsync(new EqptScanPage((int)EquiptmentScanAction.CheckOut)); });
                    break;
            }
        }

        private async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var equipment = (Equipment)layout.BindingContext;
            await Navigation.PushAsync(new EqptDetailPage(equipment));
        }

        private async void CheckInItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EqptScanPage((int)EquiptmentScanAction.CheckIn));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Equipments?.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}