using QOBDCommon.Classes;
using QOBDGateway.Abstracts;
using QOBDGateway.Classes;

namespace QOBDViewModels.Interfaces
{
    public interface IStartup
    {
        QOBDDAL.Interfaces.IQOBDSet DataSet { get; }
        ClientProxy ProxyClient { get; }
        DataAccess Dal { get; }
        BusinessLogic Bl { get; }

        void initialize();        
    }
}
