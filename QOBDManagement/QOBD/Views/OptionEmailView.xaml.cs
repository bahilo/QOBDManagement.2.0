using QOBD.Classes;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for OptionEmailView.xaml
    /// </summary>
    public partial class OptionEmailView : UserControl
    {
        public OptionEmailView()
        {
            InitializeComponent();
        }

        private void OptionEmailView_Loaded(object sender, RoutedEventArgs e)
        {
            UIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                {
                    ((IMainWindowViewModel)this.DataContext).ReferentialViewModel.OptionEmailViewModel.load();
                }
                
            }
        }
    }
}
