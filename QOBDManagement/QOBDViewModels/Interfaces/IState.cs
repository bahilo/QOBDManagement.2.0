using QOBDViewModels.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IState
    {
        void Handle(Context context, Func<object, object> page);
    }
}
