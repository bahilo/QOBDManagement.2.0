using QOBDCommon.Classes;
using QOBDViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IReferentialViewModel
    {
        BusinessLogic Bl { get; }
        IMainWindowViewModel MainWindowViewModel { get; set; }
        IOptionGeneralViewModel OptionGeneralViewModel { get; set; }
        IOptionDataAndDisplayViewModel OptionDataAndDisplayViewModel { get; set; }
        IOptionSecurityViewModel OptionSecurityViewModel { get; set; }
        ISideBarViewModel ReferentialSideBarViewModel { get; set; }
        IOptionEmailViewModel OptionEmailViewModel { get; set; }

        void Dispose();
        void executeNavig(string obj);
    }
}
