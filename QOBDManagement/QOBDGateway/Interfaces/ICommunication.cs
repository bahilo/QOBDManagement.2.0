using QOBDGateway.Abstracts;
using QOBDGateway.Classes;

namespace QOBDGateway.Interfaces
{
    public interface ICommunication
    {
        void resetCommunication();
        ClientConcreteProxy getProxy();
        void checkServiceCommunication(ClientProxy proxy);
    }
}
