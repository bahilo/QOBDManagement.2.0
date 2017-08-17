using QOBDViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QOBDModels.Command;

namespace QOBDViewModels.Classes
{
    public class CommandConcreteCreator : Creator
    {
        public override ButtonCommand<input> createSingleInputCommand<input>(Action<input> action, Func<input, bool> canPerformAction)
        {
            return new ButtonCommand<input>(action, canPerformAction);
        }
    }
}
