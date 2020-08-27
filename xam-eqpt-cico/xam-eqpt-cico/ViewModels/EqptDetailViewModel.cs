using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using xam_eqpt_cico.Models;
using Xamarin.Forms;

namespace xam_eqpt_cico.ViewModels
{
    public class EqptDetailViewModel : BaseViewModel
    {
        #region Fields

        private string text = string.Empty;
        private Equipment equipment;

        #endregion

        #region Properties

        public Equipment Equipment
        {
            get { return equipment; }
            set { SetProperty(ref equipment, value); }
        }

        public ImageSource Image
        {
            get
            {
                return ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(equipment.ImageObj)));
            }
        }

        #endregion


        public EqptDetailViewModel(Equipment equipment)
        {
            Equipment = equipment;
        }
    }
}
