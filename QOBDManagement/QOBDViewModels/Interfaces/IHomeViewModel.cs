using QOBDModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IHomeViewModel
    {
        string TxtMaterialDesignColourName { get; }
        string TxtColourName { get; }

        ButtonCommand<string> CommandNavig { get; set; }

        void load();
        void Dispose();
    }
}
