using QOBD.Classes;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for ItemProviderView.xaml
    /// </summary>
    public partial class ItemProviderView : UserControl
    {
        public ItemProviderView()
        {
            InitializeComponent();
        }

        private void ItemProvider_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                {
                    ((IMainWindowViewModel)this.DataContext).ItemViewModel.loadItems();
                }
            }
        }
    }
}
