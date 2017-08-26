using System.Collections.Generic;
using System.ComponentModel;
using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Command;
using QOBDModels.Models;

namespace QOBDViewModels.Interfaces
{
    public interface IItemDetailViewModel
    {
        BusinessLogic Bl { get; }
        ItemModel SelectedItemModel { get; set; }
        string Title { get; set; }

        ButtonCommand<string> btnDeleteCommand { get; set; }
        ButtonCommand<string> btnValidCommand { get; set; }
        ButtonCommand<object> OpenFileExplorerCommand { get; set; }
        ButtonCommand<object> SearchCommand { get; set; }

        void Dispose();
        void onItemNameChange_generateReference(object sender, PropertyChangedEventArgs e);
        void updateItemImage(List<Info> infoDataList);
    }
}