using QOBDViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QOBDModels.Classes;

namespace QOBDViewModels.Classes
{
    public class ImageConcreteCreator : Creator
    {
        public override InfoDisplay createImage(string fileNameWithoutExtension, List<string> filter, string ftpPath = "", string localPath = "", string login = "", string password = "")
        {
            return new InfoDisplay(fileNameWithoutExtension, filter, ftpPath, localPath, login, password);
        }
    }
}
