using QOBD.Classes;
using QOBD.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for AgentSideBarView.xaml
    /// </summary>
    public partial class AgentSideBarView : UserControl
    {
        public AgentSideBarView()
        {
            InitializeComponent();
        }

        private void AgentSideBarView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            dataContext.setWindowContext(this);
        }
    }
}
