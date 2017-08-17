using QOBD.Classes;
using QOBD.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for HomeChatRoomView.xaml
    /// </summary>
    public partial class HomeChatRoomView : UserControl
    {
        public HomeChatRoomView()
        {
            InitializeComponent();
        }

        private void HomeChatRoomView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }

}
