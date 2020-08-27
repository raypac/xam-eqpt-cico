using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xam_eqpt_cico.Models;
using xam_eqpt_cico.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xam_eqpt_cico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EqptDetailPage : ContentPage
    {
        EqptDetailViewModel viewModel;

        public EqptDetailPage(Equipment equipment)
        {
            InitializeComponent();

            Title = "Equipment Details";

            BindingContext = this.viewModel = new EqptDetailViewModel(equipment);
        }
    }
}