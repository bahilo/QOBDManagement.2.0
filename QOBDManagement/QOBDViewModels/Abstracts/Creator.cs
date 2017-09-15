using QOBDCommon.Exceptions;
using QOBDModels.Classes;
using QOBDModels.Command;
using QOBDModels.Enums;
using QOBDModels.Interfaces;
using QOBDViewModels.Classes;
using QOBDViewModels.Enums;
using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Abstracts
{
    public abstract class Creator
    {
        public virtual InfoDisplay createImage(string fileNameWithoutExtension, List<string> filter, string ftpPath = "", string localPath = "", string login = "", string password = "")
        {
            throw new NotApplicableException("Cannot create image for the targeted object!");
        }

        public virtual object createViewModel(EViewModel viewModelName, IMainWindowViewModel mainViewModel, object param = null)
        {
            throw new NotApplicableException("Cannot create view model for the targeted object!");
        }

        public virtual object createChatViewModel(EViewModel viewModelName, IChatRoomViewModel mainChatViewModel)
        {
            throw new NotApplicableException("Cannot create chat view model for the targeted object!");
        }

        public virtual Context createContext(IMainWindowViewModel mainViewModel)
        {
            throw new NotApplicableException("Cannot create context for the targeted object!");
        }

        public virtual ButtonCommand<input> createSingleInputCommand<input>(System.Action<input> action, Func<input, bool> canPerformAction)
        {
            throw new NotApplicableException("Cannot create command for the targeted object!");
        }

        public virtual object createSettingViewModel(EViewModel viewModelName, IReferentialViewModel mainSettingViewModel)
        {
            throw new NotApplicableException("Cannot create setting view model for the targeted object!");
        }
    }
}
