using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OptionDataAndDisplayView.xaml
    /// </summary>
    public partial class OptionDataAndDisplayView : UserControl
    {
        public OptionDataAndDisplayView()
        {
            InitializeComponent();
        }

        private void OptionDataAndDisplayView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContex = new UIContext();
            if (dataContex.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                    ((IMainWindowViewModel)this.DataContext).ReferentialViewModel.OptionDataAndDisplayViewModel.load();
            }
        }
    }
}
