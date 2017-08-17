using QOBD.Classes;
using QOBD.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OrderSideBarView.xaml
    /// </summary>
    public partial class OrderSideBarView : UserControl
    {
        public OrderSideBarView()
        {
            InitializeComponent();
        }

        private void OrderSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
