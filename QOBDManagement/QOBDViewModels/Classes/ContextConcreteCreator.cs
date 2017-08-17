using QOBDViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QOBDModels.Classes;
using QOBDModels.Interfaces;
using QOBDViewModels.Interfaces;

namespace QOBDViewModels.Classes
{
    public class ContextConcreteCreator: Creator
    {
        public override Context createContext(IMainWindowViewModel mainViewModel)
        {
            return new Context(mainViewModel);
        }
    }
}
