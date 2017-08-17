using QOBDViewModels.Classes;
using QOBDViewModels.Interfaces;
using QOBDViewModels.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for ChatRoomView.xaml
    /// </summary>
    public partial class ChatRoomView : UserControl
    {

        public ChatRoomView()
        {
            InitializeComponent();
        }

        private void ChatRoomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext as ViewModel != null)
            {
                ((ViewModel)this.DataContext).load();
            }
        }
    }
}
