using QOBD.Classes;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OptionSecurityView.xaml
    /// </summary>
    public partial class OptionSecurityView : UserControl
    {
        public OptionSecurityView()
        {
            InitializeComponent();
        }

        private void OptionSecurityView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                    ((IMainWindowViewModel)this.DataContext).ReferentialViewModel.OptionSecurityViewModel.load();
            }
        }
    }
}
