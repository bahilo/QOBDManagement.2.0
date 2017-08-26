using System.Collections.Generic;
using System.Windows;
using QOBDCommon.Classes;
using QOBDModels.Command;
using QOBDModels.Models;

namespace QOBDViewModels.Interfaces
{
    public interface IAgentDetailViewModel
    {
        List<AgentModel> AgentModelList { get; set; }
        ISideBarViewModel AgentSideBarViewModel { get; set; }
        BusinessLogic Bl { get; }
        AgentModel SelectedAgentModel { get; set; }
        string Title { get; set; }

        ButtonCommand<object> OpenFileExplorerCommand { get; set; }
        ButtonCommand<AgentModel> SearchCommand { get; set; }
        ButtonCommand<object> UpdateCommand { get; set; }

        void Dispose();
        void load();
        void onPwdBoxPasswordChange_updateTxtClearPassword(object sender, RoutedEventArgs e);
        void onPwdBoxVerificationPasswordChange_updateTxtClearPasswordVerification(object sender, RoutedEventArgs e);
    }
}