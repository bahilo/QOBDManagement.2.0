using QOBDCommon.Entities;
using QOBDModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IAgentViewModel
    {
        List<AgentModel> agentListToModelViewList(List<Agent> AgentList);
        Task loadAgents();
        void Dispose();
    }
}
