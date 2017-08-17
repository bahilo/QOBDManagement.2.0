using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OrderDetailView.xaml
    /// </summary>
    public partial class OrderDetailView : UserControl
    {
        public OrderDetailView()
        {
            InitializeComponent();
        }

        private void OrderDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                {
                    ((IMainWindowViewModel)this.DataContext).OrderViewModel.OrderDetailViewModel.load();
                }
            }
        }
    }
}
