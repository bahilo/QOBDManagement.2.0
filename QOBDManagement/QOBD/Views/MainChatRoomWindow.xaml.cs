using QOBDModels.Models;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for MainChatRoomWindow.xaml
    /// </summary>
    public partial class MainChatRoomWindow : UserControl
    {
        public MainChatRoomWindow()
        {
            InitializeComponent();
        }

        private void MainChatRoom_loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext as IChatRoomViewModel != null)
                ((IChatRoomViewModel)this.DataContext).DiscussionViewModel.DiscussionModel = (DiscussionModel)((IChatRoomViewModel)this.DataContext).MainWindowViewModel.ModelCreator.createModel(QOBDModels.Enums.EModel.DISCUSSION);
        }
    }
}
