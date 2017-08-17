using QOBD.Classes;
using QOBD.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for ClientDetailView.xaml
    /// </summary>
    public partial class ClientDetailView : UserControl
    {
        public ClientDetailView()
        {
            InitializeComponent();
        }

        private void ClientDetailWinDow_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
