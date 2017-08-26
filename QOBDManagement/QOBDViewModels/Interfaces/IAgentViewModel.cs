using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
using QOBDModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IAgentViewModel
    {


        string TxtIconColour { get; }
        BusinessLogic Bl { get; }
        string Title { get; set; }
        AgentModel AgentModel { get; set; }
        List<AgentModel> AgentModelList { get; set; }
        List<AgentModel> ActiveAgentModelList { get; }
        List<AgentModel> DeactivatedAgentModelList { get; }
        AgentModel SelectedAgentModel { get; set; }
        IAgentDetailViewModel AgentDetailViewModel { get; set; }
        ISideBarViewModel AgentSideBarViewModel { get; set; }
        List<AgentModel> UserModelList { get; }
        bool IsAuthenticatedAgentAdmin { get; }
        List<string> UserGroupList { get; set; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<AgentModel> CheckBoxCommand { get; set; }
        ButtonCommand<string> NavigCommand { get; set; }
        ButtonCommand<AgentModel> GetCurrentAgentCommand { get; set; }
        ButtonCommand<AgentModel> ClientMoveCommand { get; set; }

        void executeNavig(string obj);
        List<AgentModel> agentListToModelViewList(List<Agent> AgentList);
        Task loadAgents();
        void Dispose();
    }
}
