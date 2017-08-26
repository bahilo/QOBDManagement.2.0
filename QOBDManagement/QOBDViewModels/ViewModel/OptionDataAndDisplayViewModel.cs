using Microsoft.Win32;
using QOBDCommon.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using QOBDCommon.Entities;
using System.Collections.ObjectModel;
using System.Globalization;
using QOBDViewModels.Interfaces;
using QOBDCommon.Enum;
using QOBDViewModels.Helper;
using System.Configuration;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Classes.Themes;
using System.IO;
using QOBDDAL.Core;
using System.Windows;

namespace QOBDViewModels.ViewModel
{
    public class OptionDataAndDisplayViewModel : Classes.ViewModel
    {
        private ObservableCollection<InfoDisplay> _imageList;
        private int _imageWidth;
        private int _imageHeight;  
        private CultureInfo[] _cultureInfoArray;
        private string _title;
        private IReferentialViewModel _referential;
        private InfoDisplay _theme;
        private InfoDisplay _headerImageDisplay;
        private InfoDisplay _logoImageDisplay;
        private InfoDisplay _billImageDisplay;

        //----------------------------[ Commands ]------------------

        public ButtonCommand<InfoDisplay> OpenFileExplorerCommand { get; set; }
        public ButtonCommand<InfoDisplay> DeleteImageCommand { get; set; }
        public ButtonCommand<string> UpdateLanguageCommand { get; set; }
        public ButtonCommand<string> AddNewRowLanguageCommand { get; set; }
        public ButtonCommand<bool> ToggleThemeBaseCommand { get; set; }
        public ButtonCommand<Swatch> ApplyThemeAccentStyleCommand { get; set; }
        public ButtonCommand<Swatch> ApplyThemePrimaryStyleCommand { get; set; }

        public OptionDataAndDisplayViewModel() : base()
        {
            
        }

        public OptionDataAndDisplayViewModel(IReferentialViewModel viewModel):this()
        {
            _referential = viewModel;
            instances();
            instancesCommand();
            initEvents();
        }

        //----------------------------[ Initialization ]------------------

        private void initEvents()
        {
            _referential.MainWindowViewModel.Startup.Dal.DALReferential.PropertyChanged += onGeneralInfoDataDownloadingStatusChange;
        }

        private void instances()
        {
            _title = ConfigurationManager.AppSettings["title_setting_display"];
            _imageList = new ObservableCollection<InfoDisplay>();
            _cultureInfoArray = CultureInfo.GetCultures(CultureTypes.AllCultures & CultureTypes.NeutralCultures);

            _theme = new InfoDisplay();

            // palette initialization
            //_swatches = new SwatchesProvider().Swatches;

            //------[ Images ]
            _headerImageDisplay = _referential.MainWindowViewModel.ImageCreator.createImage("header_image", new List<string> { "header_image", "header_image_width", "header_image_height" }, ConfigurationManager.AppSettings["ftp_image_folder"], ConfigurationManager.AppSettings["local_image_folder"], "", "");
            _logoImageDisplay = _referential.MainWindowViewModel.ImageCreator.createImage("logo_image", new List<string> { "logo_image", "logo_image_width", "logo_image_height" }, ConfigurationManager.AppSettings["ftp_image_folder"], ConfigurationManager.AppSettings["local_image_folder"], "", "");
            _billImageDisplay = _referential.MainWindowViewModel.ImageCreator.createImage("bill_image", new List<string> { "bill_image", "bill_image_width", "bill_image_height" }, ConfigurationManager.AppSettings["ftp_image_folder"], ConfigurationManager.AppSettings["local_image_folder"], "", "");
        }

        private void instancesCommand()
        {
            OpenFileExplorerCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<InfoDisplay>(getFileFromLocal, canGetFileFromLocal);
            DeleteImageCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<InfoDisplay>(deleteImage, canDeleteImage);
            ToggleThemeBaseCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<bool>(changeTheme, canChangeTheme);
            ApplyThemeAccentStyleCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<Swatch>(applyThemeAccentStyle, canApplyThemeAccentStyle);
            ApplyThemePrimaryStyleCommand = _referential.MainWindowViewModel.CommandCreator.createSingleInputCommand<Swatch>(applyThemePrimaryStyle, canApplyThemePrimaryStyle);
        }

        //----------------------------[ Properties ]------------------


        public BusinessLogic Bl
        {
            get { return _referential.MainWindowViewModel.Startup.Bl; }
        }

        public InfoDisplay Theme
        {
            get { return _theme; }
            set { setProperty(ref _theme, value); }
        }

        public string Title
        {
            get { return _title; }
            set { setProperty(ref _title, value); }
        }

        public InfoDisplay HeaderImageDisplay
        {
            get { return _headerImageDisplay; }
            set
            {
                _headerImageDisplay = value;
                onPropertyChange();
            }
        }

        public InfoDisplay LogoImageDisplay
        {
            get { return _logoImageDisplay; }
            set { _logoImageDisplay = value; onPropertyChange(); }
        }

        public InfoDisplay BillImageDisplay
        {
            get { return _billImageDisplay; }
            set { _billImageDisplay = value; onPropertyChange(); }
        }

        public int ImageWidth
        {
            get { return _imageWidth; }
            set { setProperty(ref _imageWidth, value); }
        }

        public int ImageHeight
        {
            get { return _imageHeight; }
            set { setProperty(ref _imageHeight, value); }
        }

        public ObservableCollection<InfoDisplay> ImageList
        {
            get { return _imageList; }
            set { setProperty(ref _imageList, value); }
        }

        public CultureInfo[] CultureInfoArray
        {
            get { return _cultureInfoArray; }
            set { setProperty(ref _cultureInfoArray, value); }
        }

        
        //----------------------------[ Actions ]------------------

        public override void load()
        {
            loadImages();
        }

        private void loadImages()
        {
            Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["load_message"]);
            Dispose();
            ImageList.Clear();

            //----[ Bill Image ]
            // get invoice image and create listener on image info change
            _billImageDisplay.PropertyChanged += onFilePathChange_updateUIImage;
            _billImageDisplay.PropertyChanged += onImageInfoChange;
            ImageList.Add(_billImageDisplay);

            //----[ Logo Image ]
            // get logo image and create listener on image info change
            _logoImageDisplay.PropertyChanged += onFilePathChange_updateUIImage;
            _logoImageDisplay.PropertyChanged += onImageInfoChange;
            ImageList.Add(_logoImageDisplay);

            //----[ Header Image ] 
            // get header image and create listener on image info change
            _headerImageDisplay.PropertyChanged += onFilePathChange_updateUIImage;
            _headerImageDisplay.PropertyChanged += onImageInfoChange;
            ImageList.Add(_headerImageDisplay);
            
            Singleton.getDialogueBox().IsDialogOpen = false;
        }

        /*public string ExecuteOpenFileDialog()
        {
            string outputFile = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose image file";
            openFileDialog.Filter = "Image Files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
                outputFile = openFileDialog.FileName;

            return outputFile;
        }*/

        public async Task<List<Info>> saveInfo(List<Info> infoDataList)
        {
            var infoToUpdateList = infoDataList.Where(x => x.ID != 0).ToList();
            var infoToCreateList = infoDataList.Where(x => x.ID == 0).ToList();
            var infoUpdatedList = await Bl.BlReferential.UpdateInfoAsync(infoToUpdateList);
            var infoCreatedList = await Bl.BlReferential.InsertInfoAsync(infoToCreateList);

            if (infoUpdatedList.Count == 0 && infoCreatedList.Count == 0)
            {
                string errorMessage = "Error occurred while saving the picture information!";
                Log.error(errorMessage, EErrorFrom.REFERENTIAL);
                await Singleton.getDialogueBox().showAsync(errorMessage);
            }
            else if(infoCreatedList.Count > 0)
            {
                foreach(Info info in infoDataList)
                {
                    var createdInfo = infoCreatedList.Where(x=>x.Name == info.Name).SingleOrDefault();
                    if(createdInfo != null)
                        info.ID = createdInfo.ID;
                }
            }                        
            
            return infoUpdatedList.Concat(infoCreatedList).ToList();
        }

        private async void downloadHeaderImages()
        {
            await Task.Factory.StartNew(() => {
                // set ftp credentials
                if (string.IsNullOrEmpty(_headerImageDisplay.TxtLogin) || string.IsNullOrEmpty(_logoImageDisplay.TxtLogin) || string.IsNullOrEmpty(_billImageDisplay.TxtLogin))
                {
                    _headerImageDisplay.TxtLogin = _logoImageDisplay.TxtLogin = _billImageDisplay.TxtLogin = (Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = "ftp_login" }, ESearchOption.OR).FirstOrDefault() ?? new Info()).Value;
                    _headerImageDisplay.TxtPassword = _logoImageDisplay.TxtPassword = _billImageDisplay.TxtPassword = (Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = "ftp_password" }, ESearchOption.OR).FirstOrDefault() ?? new Info()).Value;
                }

                // download header image
                if (string.IsNullOrEmpty(_headerImageDisplay.TxtFileFullPath))
                {
                    var headerImageFoundDisplay = loadImage(HeaderImageDisplay);
                    if (!string.IsNullOrEmpty(headerImageFoundDisplay.TxtFileFullPath) && File.Exists(headerImageFoundDisplay.TxtFileFullPath))
                        HeaderImageDisplay = headerImageFoundDisplay;
                }

                // download header logo
                if (string.IsNullOrEmpty(_logoImageDisplay.TxtFileFullPath))
                {
                    var logoImageFoundDisplay = loadImage(LogoImageDisplay);
                    if (!string.IsNullOrEmpty(logoImageFoundDisplay.TxtFileFullPath) && File.Exists(logoImageFoundDisplay.TxtFileFullPath))
                        LogoImageDisplay = logoImageFoundDisplay;
                }

                // download the bill image
                if (string.IsNullOrEmpty(_billImageDisplay.TxtFileFullPath))
                {
                    var billImageFoundDisplay = loadImage(BillImageDisplay);
                    if (!string.IsNullOrEmpty(billImageFoundDisplay.TxtFileFullPath) && File.Exists(billImageFoundDisplay.TxtFileFullPath))
                        BillImageDisplay = billImageFoundDisplay;
                }
            });
        }

        public InfoDisplay loadImage(InfoDisplay image)
        {
            image.InfoDataList = Bl.BlReferential.searchInfo(new QOBDCommon.Entities.Info { Name = image.TxtFileNameWithoutExtension }, ESearchOption.AND);
            image.downloadFile();
            return image;
        }

        private InfoDisplay imageManagement(InfoDisplay newImage = null, string fileType = null)
        {
            switch (fileType.ToUpper())
            {
                case "HEADER":
                    if (newImage != null)
                        HeaderImageDisplay = newImage;
                    return HeaderImageDisplay;
                case "LOGO":
                    if (newImage != null)
                        LogoImageDisplay = newImage;

                    return LogoImageDisplay;
                case "BILL":
                    if (newImage != null)
                        BillImageDisplay = newImage;

                    return BillImageDisplay;
            }

            return new InfoDisplay();
        }


        public override void Dispose()
        {
            foreach (var image in ImageList)
            {
                image.PropertyChanged -= onFilePathChange_updateUIImage;
                image.PropertyChanged -= onImageInfoChange;
                Theme.PropertyChanged -= onImageInfoChange;
                _referential.MainWindowViewModel.Startup.Dal.DALReferential.PropertyChanged -= onGeneralInfoDataDownloadingStatusChange;
                image.Dispose();
            }
        }

        //----------------------------[ Event Handler ]------------------
        
        private async void onImageInfoChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ImageInfoUpdated"))
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["update_message"]);
                var infoUpdatedList = await saveInfo(((InfoDisplay)sender).InfoDataList);
                Singleton.getDialogueBox().IsDialogOpen = false;
            }                
        }

        private void onFilePathChange_updateUIImage(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("TxtFileFullPath") && !string.IsNullOrEmpty(((InfoDisplay)sender).TxtFileFullPath) )
            {
                if (((InfoDisplay)sender).TxtFileNameWithoutExtension.Equals("header_image"))
                    imageManagement((InfoDisplay)sender, "header");
                else if(((InfoDisplay)sender).TxtFileNameWithoutExtension.Equals("logo_image"))
                    imageManagement((InfoDisplay)sender, "logo");
                else if (((InfoDisplay)sender).TxtFileNameWithoutExtension.Equals("bill_image"))
                    imageManagement((InfoDisplay)sender, "bill");
            }
        }

        /// <summary>
        /// event listener to download the IU images on caching executed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onGeneralInfoDataDownloadingStatusChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsDataDownloading") && !((DALReferential)sender).IsDataDownloading)
            {
                // if not unit testing download images
                if (Application.Current != null)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                    {
                        // reload user information
                        await _referential.MainWindowViewModel.ChatRoomViewModel.getChatUserInformation();

                        downloadHeaderImages();
                    }
                    else
                        await Application.Current.Dispatcher.Invoke(async () =>
                        {
                            // reload user information
                            await _referential.MainWindowViewModel.ChatRoomViewModel.getChatUserInformation();

                            downloadHeaderImages();
                        });
                }
            }
        }

        //----------------------------[ Action Commands ]------------------

        /// <summary>
        /// load and save file information into database
        /// </summary>
        /// <param name="obj">object which the file is associated with</param>
        public async void getFileFromLocal(InfoDisplay obj)
        {
            await Task.Factory.StartNew(()=> {
                // opening the file explorer for image file choosing
                string imageFile = InfoGeneral.ExecuteOpenFileDialog("Select an image file", new List<string> { "png", "jpeg", "jpg" });
                if (!string.IsNullOrEmpty(imageFile))
                {
                    string msg = ConfigurationManager.AppSettings["wait_message"];
                    Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["wait_message"]);
                    obj.TxtChosenFile = imageFile;

                    // upload the image file to the server FTP
                    obj.uploadImage();

                    Singleton.getDialogueBox().IsDialogOpen = false;
                }
            });        
        }

        private bool canGetFileFromLocal(InfoDisplay arg)
        {
            return true;
        }

        private async void deleteImage(InfoDisplay obj)
        {
            if (await Singleton.getDialogueBox().showAsync("Do you really want to delete this image ["+obj.TxtFileName+"] ?"))
            {
                Singleton.getDialogueBox().showSearch(ConfigurationManager.AppSettings["delete_message"]);
                var notDeletedInfosList = await Bl.BlReferential.DeleteInfoAsync(obj.InfoDataList);
                var whereImageInfosIDIsZeroList = obj.InfoDataList.Where(x => x.ID == 0 && x.Name.Equals(obj.TxtFileNameWithoutExtension)).ToList();
                if ((notDeletedInfosList.Count == 0 || whereImageInfosIDIsZeroList.Count > 0) && obj.deleteFiles())
                {
                    var credentials = Bl.BlReferential.searchInfo(new Info { Name = "ftp_" }, ESearchOption.AND);
                    if (WPFHelper.deleteFileFromFtpServer(ConfigurationManager.AppSettings["ftp_image_folder"], obj.TxtFileName, credentials))
                    {
                        await Singleton.getDialogueBox().showAsync(obj.TxtFileName + " has been successfully deteleted!");
                        obj.TxtFileFullPath = "";
                    }
                    else
                    {
                        string errorMessage = "Error occurred while deleting the image ["+obj.TxtFileName+"]";
                        Log.error(errorMessage, EErrorFrom.REFERENTIAL);
                        Singleton.getDialogueBox().showSearch(errorMessage);
                    }
                    
                }

                // reset the picture information
                foreach (Info info in obj.InfoDataList)
                    info.ID = 0;

                Singleton.getDialogueBox().IsDialogOpen = false;
            }            
        }

        private bool canDeleteImage(InfoDisplay arg)
        {
            return true;
        }

        private void changeTheme(bool obj)
        {
            new PaletteHelper().SetLightDark(obj);
            Theme.TxtInfoItem = obj ? "Dark" : "Light";
        }

        private bool canChangeTheme(bool arg)
        {
            return true;
        }

        private void applyThemePrimaryStyle(Swatch obj)
        {
            new PaletteHelper().ReplacePrimaryColor(obj);
            Theme.TxtInfoItem1 = obj.Name;
        }

        private bool canApplyThemePrimaryStyle(Swatch arg)
        {
            return true;
        }

        private void applyThemeAccentStyle(Swatch obj)
        {
            new PaletteHelper().ReplaceAccentColor(obj);
            Theme.TxtInfoItem2 = obj.Name;
        }

        private bool canApplyThemeAccentStyle(Swatch arg)
        {
            return true;
        }


    }
}
