using QOBD.Classes;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for ItemSideBarView.xaml
    /// </summary>
    public partial class ItemSideBarView : UserControl
    {
        public ItemSideBarView()
        {
            InitializeComponent();
        }

        private void ItemSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
