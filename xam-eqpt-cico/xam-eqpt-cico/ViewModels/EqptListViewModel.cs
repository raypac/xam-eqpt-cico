using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using xam_eqpt_cico.Models;
using xam_eqpt_cico.Views;
using Xamarin.Forms;

namespace xam_eqpt_cico.ViewModels
{
    public class EqptListViewModel : BaseViewModel
    {
        public ObservableCollection<Equipment> Equipments { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EqptListViewModel()
        {
            Title = "Browse Equipment";
            Equipments = new ObservableCollection<Equipment>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Equipments.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Equipments.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
