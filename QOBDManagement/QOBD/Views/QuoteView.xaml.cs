using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for QuoteView.xaml
    /// </summary>
    public partial class QuoteView : UserControl
    {
        public QuoteView()
        {
            InitializeComponent();
        }

        private void QuoteView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                    ((IMainWindowViewModel)this.DataContext).QuoteViewModel.loadQuotations();
            }
        }
    }
}
