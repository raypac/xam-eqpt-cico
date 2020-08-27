using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xam_eqpt_cico.Utilities;
using ZXing;
using static xam_eqpt_cico.Utilities.StaticDefinition;

namespace xam_eqpt_cico.ViewModels
{
    public class EqptScanViewModel: BaseViewModel
    {
        #region Fields

        private Result result;

        private string qr = string.Empty;
        private bool isAnalyzing = true;
        private bool isScanning = true;
        private bool isCheckInSuccess = false;
        private int scanAction;

        #endregion

        #region Properties

        public Result Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        public string Qr
        {
            get { return qr; }
            set { SetProperty(ref qr, value); }
        }

        public bool IsAnalyzing
        {
            get { return isAnalyzing; }
            set { SetProperty(ref isAnalyzing, value); }
        }

        public bool IsScanning
        {
            get { return isScanning; }
            set { SetProperty(ref isScanning, value); }
        }

        public bool IsCheckInSuccess
        {
            get { return isCheckInSuccess; }
            set { SetProperty(ref isCheckInSuccess, value); }
        }

        public int ScanAction
        {
            get { return scanAction; }
            set { SetProperty(ref scanAction, value); }
        }

        #endregion

        #region Constructors

        public EqptScanViewModel(int scanAction = 0)
        {
            this.ScanAction = scanAction;
        }

        #endregion

        #region Methods

        public async Task CheckInEquipmentAsync()
        {
            Qr = Result.Text;
            var equipment = await DataStore.GetItemAsync(Qr);

            if (equipment != null)
            {
                switch (scanAction)
                {
                    case (int)EquipmentScanAction.CheckIn:
                        equipment.IsInUse = false;
                        equipment.IsInUseWhere = "";
                        break;
                    case (int)EquipmentScanAction.CheckOut:
                        equipment.IsInUse = true;
                        equipment.IsInUseWhere = "Somewhere else..";
                        break;
                }

                IsCheckInSuccess = await DataStore.UpdateItemAsync(equipment);
            }
        }

        #endregion

    }
}
