using QOBD.Classes;
using QOBD.Interfaces;
using QOBDViewModels.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for AgentDetailView.xaml
    /// </summary>
    public partial class AgentDetailView : UserControl
    {
        public AgentDetailView()
        {
            InitializeComponent();
        }

        private void AgentDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            IUIContext dataContext = new UIContext();
            if (dataContext.setWindowContext(this) != null)
            {
                ((IMainWindowViewModel)this.DataContext).AgentViewModel.AgentDetailViewModel.load();
                pwdBox.Password = ((IMainWindowViewModel)this.DataContext).AgentViewModel.AgentDetailViewModel.SelectedAgentModel.TxtHashedPassword;
                pwdBoxVerification.Password = ((IMainWindowViewModel)this.DataContext).AgentViewModel.AgentDetailViewModel.SelectedAgentModel.TxtHashedPassword;
                pwdBox.LostFocus += ((IMainWindowViewModel)this.DataContext).AgentViewModel.AgentDetailViewModel.onPwdBoxPasswordChange_updateTxtClearPassword;
                pwdBoxVerification.LostFocus += ((IMainWindowViewModel)this.DataContext).AgentViewModel.AgentDetailViewModel.onPwdBoxVerificationPasswordChange_updateTxtClearPasswordVerification;
            }
        }
    }
}
