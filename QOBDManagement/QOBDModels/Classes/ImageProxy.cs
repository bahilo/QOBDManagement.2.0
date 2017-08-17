using QOBDModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QOBDCommon.Entities;

namespace QOBDModels.Classes
{
    public class ImageProxy : IDisplay
    {
        bool _isDownloading = false;
        IDisplay _image;

        public ImageProxy(IDisplay image)
        {
            _image = image;
        }

        public string ImageLoadingMessage
        {
            get { return _image.ImageLoadingMessage; }
            set { _image.ImageLoadingMessage = value; }
        }

        public bool closeImageSource()
        {
            return _image.closeImageSource();
        }

        public bool deleteFiles()
        {
            return _image.deleteFiles();
        }

        public void downloadFile()
        {
            if (!_isDownloading)
            {
                ImageLoadingMessage = "Image loading...";
                Task.Factory.StartNew(()=> 
                {
                    _image.downloadFile();
                });
            }
        }

        public void setup()
        {
            _image.setup();
        }

        public void updateFields(List<Info> infoList)
        {
            _image.updateFields(infoList);
        }

        public void updateImageSource()
        {
            _image.updateImageSource();
        }

        public bool uploadImage()
        {
            return _image.uploadImage();
        }

    }
}
