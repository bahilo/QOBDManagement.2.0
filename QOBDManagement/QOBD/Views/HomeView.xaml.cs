using QOBD.Classes;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
