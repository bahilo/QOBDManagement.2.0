using System.Windows.Controls;

namespace QOBD.Interfaces
{
    public interface IUIContext
    {
        object setChatWindowContext(UserControl view);
        object setWindowContext(UserControl view);
    }
}