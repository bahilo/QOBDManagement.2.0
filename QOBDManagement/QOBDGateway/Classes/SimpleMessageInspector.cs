using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace QOBDGateway.Classes
{
    public class SimpleMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Debug.WriteLine("After message received!");
            Debug.WriteLine(reply.ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Debug.WriteLine("Before message sent!");
            Debug.WriteLine(request.ToString());
            return null;
        }
    }
}
