using QOBDCommon.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface ISecurityLoginViewModel
    {
        Task showLoginView();
        Task<object> authenticateAgent();
        bool securityCheck(EAction action, ESecurity right);
        void Dispose();
    }
}
