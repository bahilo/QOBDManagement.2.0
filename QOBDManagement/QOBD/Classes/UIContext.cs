using QOBD.Interfaces;
using QOBDModels.Classes;
using QOBDViewModels;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Classes
{
    public class UIContext : IUIContext
    {
        public object setWindowContext(UserControl view)
        {
            view.DataContext = null;
            var parent = FindParent.FindChildParent<Window>(view);
            if (parent != null)
            {
                view.DataContext = (MainWindowViewModel)parent.DataContext;
            }
            return view.DataContext;
        }

        public object setChatWindowContext(UserControl view)
        {
            object result = setWindowContext(view);
            if(result != null)
                view.DataContext = ((IMainWindowViewModel)result).ChatRoomViewModel;           

            return view.DataContext;
        }
    }
}
