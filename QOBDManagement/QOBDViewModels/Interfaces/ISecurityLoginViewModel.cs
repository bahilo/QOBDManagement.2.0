using QOBDCommon.Classes;
using QOBDCommon.Enum;
using QOBDModels.Command;
using QOBDModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface ISecurityLoginViewModel
    {
        string TxtPathFavicon { get; }
        string TxtInfoAllRightText { get; }
        string TxtInfoCompanyName { get; }
        string TxtWelcomeMessage { get; }
        AgentModel AgentModel { get; set; }
        BusinessLogic Bl { get; }
        string TxtErrorMessage { get; set; }
        string TxtClearPassword { get; set; }
        string TxtLogin { get; set; }
        string TxtLicenseKey { get; }

        ButtonCommand<object> LogoutCommand { get; set; }

        Task showLoginView();
        Task<object> authenticateAgent();
        bool securityCheck(EAction action, ESecurity right);
        void Dispose();
    }
}
