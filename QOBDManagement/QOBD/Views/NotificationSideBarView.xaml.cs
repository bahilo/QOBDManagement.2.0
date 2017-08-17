using QOBD.Classes;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for NotificationSideBarView.xaml
    /// </summary>
    public partial class NotificationSideBarView : UserControl
    {
        public NotificationSideBarView()
        {
            InitializeComponent();
        }

        private void NotificationSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
