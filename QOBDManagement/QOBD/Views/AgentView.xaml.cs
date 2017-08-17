using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for AgentView.xaml
    /// </summary>
    public partial class AgentView : UserControl
    {
        public AgentView()
        {
            InitializeComponent();
        }

        private async void AgentView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                if (!((IMainWindowViewModel)this.DataContext).IsThroughContext)
                    await ((IMainWindowViewModel)this.DataContext).AgentViewModel.loadAgents();
            }
        }
    }
}
