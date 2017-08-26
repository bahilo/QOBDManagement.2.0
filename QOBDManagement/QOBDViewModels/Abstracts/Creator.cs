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
            throw new NotSupportedException();
        }

        public virtual object createViewModel(EViewModel viewModelName, IMainWindowViewModel mainViewModel)
        {
            throw new NotSupportedException();
        }

        public virtual object createChatViewModel(EViewModel viewModelName, IChatRoomViewModel mainChatViewModel)
        {
            throw new NotSupportedException();
        }

        public virtual Context createContext(IMainWindowViewModel mainViewModel)
        {
            throw new NotSupportedException();
        }

        public virtual ButtonCommand<input> createSingleInputCommand<input>(System.Action<input> action, Func<input, bool> canPerformAction)
        {
            throw new NotSupportedException();
        }

        public virtual object createSettingViewModel(EViewModel viewModelName, IReferentialViewModel mainSettingViewModel)
        {
            throw new NotSupportedException();
        }
    }
}
