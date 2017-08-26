using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using QOBDCommon.Classes;
using QOBDCommon.Entities;
using QOBDModels.Classes;
using QOBDModels.Classes.Themes;
using QOBDModels.Command;

namespace QOBDViewModels.Interfaces
{
    public interface IOptionDataAndDisplayViewModel
    {
        ButtonCommand<string> AddNewRowLanguageCommand { get; set; }
        ButtonCommand<Swatch> ApplyThemeAccentStyleCommand { get; set; }
        ButtonCommand<Swatch> ApplyThemePrimaryStyleCommand { get; set; }
        InfoDisplay BillImageDisplay { get; set; }
        BusinessLogic Bl { get; }
        CultureInfo[] CultureInfoArray { get; set; }
        ButtonCommand<InfoDisplay> DeleteImageCommand { get; set; }
        InfoDisplay HeaderImageDisplay { get; set; }
        int ImageHeight { get; set; }
        ObservableCollection<InfoDisplay> ImageList { get; set; }
        int ImageWidth { get; set; }
        InfoDisplay LogoImageDisplay { get; set; }
        ButtonCommand<InfoDisplay> OpenFileExplorerCommand { get; set; }
        InfoDisplay Theme { get; set; }
        string Title { get; set; }
        ButtonCommand<bool> ToggleThemeBaseCommand { get; set; }
        ButtonCommand<string> UpdateLanguageCommand { get; set; }

        void Dispose();
        void getFileFromLocal(InfoDisplay obj);
        void load();
        InfoDisplay loadImage(InfoDisplay image);
        Task<List<Info>> saveInfo(List<Info> infoDataList);
    }
}