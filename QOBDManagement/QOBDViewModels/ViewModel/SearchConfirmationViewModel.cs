using QOBDViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.ViewModel
{
    public class SearchConfirmationViewModel : Classes.ViewModel, IConfirmationViewModel
    {
        IConfirmationViewModel _dialog;

        public SearchConfirmationViewModel(IConfirmationViewModel dialog)
        {
            _dialog = dialog;
        }

        public bool IsChatDialogOpen
        {
            get { return _dialog.IsChatDialogOpen; }
            set { _dialog.IsChatDialogOpen = value; onPropertyChange(); }
        }

        public bool IsChatLeftBarOpen
        {
            get { return _dialog.IsChatLeftBarOpen; }
            set { _dialog.IsChatLeftBarOpen = value; onPropertyChange(); }
        }

        public bool IsDialogOpen
        {
            get { return _dialog.IsDialogOpen; }
            set { _dialog.IsDialogOpen = value; onPropertyChange(); }
        }

        public bool IsLeftBarClosed
        {
            get { return _dialog.IsLeftBarClosed; }
            set { _dialog.IsLeftBarClosed = value; onPropertyChange(); }
        }

        public bool Response
        {
            get { return _dialog.Response; }
            set { _dialog.Response = value; onPropertyChange(); }
        }

        public string TxtMessage
        {
            get { return _dialog.TxtMessage; }
            set { _dialog.TxtMessage = value; onPropertyChange(); }
        }

        public Task<bool> showAsync(object viewModel, bool isChatDialogBox = false)
        {
            return _dialog.showAsync(viewModel, isChatDialogBox);
        }

        public Task<bool> showAsync(string message, bool isChatDialogBox = false)
        {
            return _dialog.showAsync(message, isChatDialogBox);
        }

        public void showSearch(string message, bool isChatDialogBox = false)
        {
            _dialog.showSearch(message, isChatDialogBox);
        }

        public void showSearchingMessage(string message, bool isChatDialogBox = false)
        {
            _dialog.showSearchingMessage(message, isChatDialogBox);
        }
    }
}
