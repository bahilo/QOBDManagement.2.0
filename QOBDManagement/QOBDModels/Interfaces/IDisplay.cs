using System.Collections.Generic;
using QOBDCommon.Entities;

namespace QOBDModels.Interfaces
{
    public interface IDisplay
    {
        string ImageLoadingMessage { get;set; }
        bool closeImageSource();
        bool deleteFiles();
        void downloadFile();
        void setup();
        void updateFields(List<Info> infoList);
        void updateImageSource();
        bool uploadImage();
    }
}