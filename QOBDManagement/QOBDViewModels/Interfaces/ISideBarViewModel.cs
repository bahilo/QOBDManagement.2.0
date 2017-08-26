using QOBDModels.Command;
using QOBDModels.Models;
using System.ComponentModel;

namespace QOBDViewModels.Interfaces
{
    public interface ISideBarViewModel
    {
        ButtonCommand<string> SetupCommand { get; set; }
        ButtonCommand<string> UtilitiesCommand { get; set; }

        void onCurrentPageChange_updateCommand(object sender, PropertyChangedEventArgs e);
    }
}