using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for StatisticView.xaml
    /// </summary>
    public partial class StatisticView : UserControl
    {
        public StatisticView()
        {
            InitializeComponent();
        }

        private void StatisticView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();

            if (dataContext.setWindowContext(this) != null && !((IMainWindowViewModel)this.DataContext).IsThroughContext)
                ((IMainWindowViewModel)this.DataContext).HomeViewModel.loadData();
        }
    }
}
