using QOBDViewModels.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace QOBD.Views
{
    /// <summary>
    /// Interaction logic for SecurityLoginView.xaml
    /// </summary>
    public partial class SecurityLoginView : UserControl
    {
        public SecurityLoginView()
        {
            InitializeComponent();
        }

        private void SecurityLoginView_Loaded(object sender, RoutedEventArgs e)
        {
            pwdBox.Clear();
            pwdBox.LostFocus += ((SecurityLoginViewModel)this.DataContext).onPwdBoxPasswordChange_updateTxtClearPassword;
        }
    }
}
