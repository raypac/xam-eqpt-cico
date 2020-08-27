using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xam_eqpt_cico.Models;
using xam_eqpt_cico.Utilities;
using static xam_eqpt_cico.Utilities.StaticDefinition;

namespace xam_eqpt_cico.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Equipment, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Equipment:
                        MenuPages.Add(id, new NavigationPage(new EqptListPage()));
                        break;
                    case (int)MenuItemType.CheckIn:
                        MenuPages.Add(id, new NavigationPage(new EqptListPage((int)EquipmentScanAction.CheckIn)));
                        break;
                    case (int)MenuItemType.CheckOut:
                        MenuPages.Add(id, new NavigationPage(new EqptListPage((int)EquipmentScanAction.CheckOut)));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}