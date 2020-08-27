using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xam_eqpt_cico.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static xam_eqpt_cico.Utilities.StaticDefinition;

namespace xam_eqpt_cico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EqptScanPage : ContentPage
    {
        EqptScanViewModel viewModel;

        public EqptScanPage(int scanAction = 0)
        {
            InitializeComponent();

            BindingContext = viewModel = new EqptScanViewModel(scanAction);

            switch (scanAction)
            {
                case (int)EquipmentScanAction.CheckIn:
                    Title = "Check-In Equipment";
                    break;
                case (int)EquipmentScanAction.CheckOut:
                    Title = "Check-Out Equipment";
                    break;
            }
        }

        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            await viewModel.CheckInEquipmentAsync();

            if (viewModel.IsCheckInSuccess)
            {
                Device.BeginInvokeOnMainThread(async () => {

                    switch (viewModel.ScanAction)
                    {
                        case (int)EquipmentScanAction.CheckIn:
                            await DisplayAlert("Info", "Equipment is now Checked-In", "OK");
                            break;
                        case (int)EquipmentScanAction.CheckOut:
                            await DisplayAlert("Info", "Equipment is now Checked-Out", "OK");
                            break;
                    }
                    await Navigation.PopAsync();
                });
            }
        }
    }
}