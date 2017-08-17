using QOBDCommon.Enum;
using QOBDModels.Classes;
using QOBDViewModels;
using QOBDViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QOBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool confirmed;
        MainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DialogHost_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel = new MainWindowViewModel(new Startup(),
                                                            new ViewModelConcreteCreator(),
                                                            new ImageConcreteCreator(),
                                                            new ContextConcreteCreator(),
                                                            new CommandConcreteCreator(),
                                                            new ModelConcreteCreator());
            this.DataContext = mainWindowViewModel;
        }

        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!confirmed && mainWindowViewModel.AuthenticatedUserModel.Agent.ID != 0 && mainWindowViewModel.AuthenticatedUserModel.TxtStatus.Equals(EStatus.Active.ToString()))
            {
                e.Cancel = true;
                if (await mainWindowViewModel.DisposeAsync())
                {
                    confirmed = true;
                    this.Close();
                }
            }
        }
    }
}
