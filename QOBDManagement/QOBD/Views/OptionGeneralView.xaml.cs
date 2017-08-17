using QOBD.Classes;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OptionGeneralView.xaml
    /// </summary>
    public partial class OptionGeneralView : UserControl
    {
        public OptionGeneralView()
        {
            InitializeComponent();
        }

        private void OptionGeneralView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                    ((IMainWindowViewModel)this.DataContext).ReferentialViewModel.OptionGeneralViewModel.load();
            }
        }
    }
}
