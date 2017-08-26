using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
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
        CLientSideBarViewModel ClientSideBarViewModel { get; set; }
        ClientModel SelectedCLientModel { get; set; }

        //----------------------------[ Commands ]------------------

        ButtonCommand<ClientModel> checkBoxResultGridCommand { get; set; }
        ButtonCommand<string> checkBoxSearchCommand { get; set; }
        ButtonCommand<string> rBoxSearchCommand { get; set; }
        ButtonCommand<Agent> btnComboBxCommand { get; set; }
        ButtonCommand<string> btnSearchCommand { get; set; }
        ButtonCommand<string> NavigCommand { get; set; }
        ButtonCommand<ClientModel> ClientDetailCommand { get; set; }
        ButtonCommand<ClientModel> rbSelectClientForQuoteCommand { get; set; }

        // actions

        void load();
        void executeNavig(string obj);
        void selectCurrentClient(ClientModel obj);
        List<ClientModel> clientListToModelViewList(List<Client> clientList);
        void Dispose();
    }
}
