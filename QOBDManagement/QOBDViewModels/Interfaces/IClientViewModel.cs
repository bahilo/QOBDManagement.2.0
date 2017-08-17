using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Models;
using QOBDViewModels.ViewModel;
using System.Collections.Generic;

namespace QOBDViewModels.Interfaces
{
    public interface IClientViewModel
    {
        // properties

        BusinessLogic Bl { get; }
        string Title { get; set; }
        List<ClientModel> ClientModelList { get; set; }
        List<Agent> AgentList { get; set; }
        ClientDetailViewModel ClientDetailViewModel { get; set; }
        ClientModel SelectedCLientModel { get; set; }
        ClientModel ClientModel { get; set; }


        // actions

        void loadClients();
        List<ClientModel> clientListToModelViewList(List<Client> clientList);
        void Dispose();
    }
}
