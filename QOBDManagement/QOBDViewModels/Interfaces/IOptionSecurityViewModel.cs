using System.Collections.Generic;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
using QOBDModels.Models;

namespace QOBDViewModels.Interfaces
{
    public interface IOptionSecurityViewModel
    {
        Dictionary<int, Role> AgentCredentialHeaderTable { get; set; }
        List<AgentModel> AgentModelList { get; set; }
        BusinessLogic Bl { get; }
        ButtonCommand<AgentModel> CbxGetSelectedAgentCommand { get; set; }
        ButtonCommand<RoleModel> CbxGetSelectedRoleCommand { get; set; }
        Role HeaderRole1 { get; }
        Role HeaderRole2 { get; }
        Role HeaderRole3 { get; }
        Role HeaderRole4 { get; }
        Role HeaderRole5 { get; }
        Role HeaderRole6 { get; }
        Role HeaderRole7 { get; }
        Role HeaderRole8 { get; }
        Role HeaderRole9 { get; }
        List<RoleModel> RoleModelList { get; set; }
        string Title { get; set; }
        ButtonCommand<object> UpdateCredentialCommand { get; set; }

        void Dispose();
        Task<List<AgentModel>> getAgentModelAsync();
        Task<List<RoleModel>> getRoleModelAsync();
        void load();
    }
}