using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace QOBDGateway.Classes
{
    public class SimpleBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(SimpleEndPointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new SimpleEndPointBehavior();
        }
    }
}
