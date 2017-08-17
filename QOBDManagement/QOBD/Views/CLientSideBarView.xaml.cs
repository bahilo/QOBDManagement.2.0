using QOBD.Classes;
using QOBD.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for CLientSideBarView.xaml
    /// </summary>
    public partial class CLientSideBarView : UserControl
    {
        public CLientSideBarView()
        {
            InitializeComponent();
        }

        private void CLientSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
