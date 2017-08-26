using System.Collections.Generic;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Models;
using System.ComponentModel;

namespace QOBDViewModels.Interfaces
{
    public interface IMessageViewModel
    {
        Agent AuthenticatedUser { get; }
        BusinessLogic BL { get; }
        int MaxMessageLength { get; }
        Dictionary<AgentModel, Pair<MessageModel, int>> MessageGroupHistoryList { get; set; }
        Dictionary<AgentModel, Pair<MessageModel, int>> MessageIndividualHistoryList { get; set; }


        void Dispose();
        void addObserver(PropertyChangedEventHandler observerMethode);
        void removeObserver(PropertyChangedEventHandler observerMethode);
        Task loadAsync();
    }
}