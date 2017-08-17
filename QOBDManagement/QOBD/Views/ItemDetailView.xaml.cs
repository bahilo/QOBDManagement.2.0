using QOBD.Classes;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for ItemDetailView.xaml
    /// </summary>
    public partial class ItemDetailView : UserControl
    {
        public ItemDetailView()
        {
            InitializeComponent();
        }

        private void ItemDetailView_Loaded(object sender, RoutedEventArgs e)
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
