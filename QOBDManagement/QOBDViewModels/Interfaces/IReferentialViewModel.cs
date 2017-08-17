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
        OptionGeneralViewModel OptionGeneralViewModel { get; set; }
        OptionDataAndDisplayViewModel OptionDataAndDisplayViewModel { get; set; }
        OptionSecurityViewModel OptionSecurityViewModel { get; set; }
        ReferentialSideBarViewModel ReferentialSideBarViewModel { get; set; }
        OptionEmailViewModel OptionEmailViewModel { get; set; }
    }
}
