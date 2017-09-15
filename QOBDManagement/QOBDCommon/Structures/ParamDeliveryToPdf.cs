﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDCommon.Structures
{
    public struct ParamDeliveryToPdf
    {
        private int _commandId;
        private int _deliveryId;
        private string _lang;
        private string _licenseKey;

        public ParamDeliveryToPdf(int commandId, int deliveryId)
        {
            _commandId = commandId;
            _deliveryId = deliveryId;
            _licenseKey = "";
            _lang = "";
        }

        public string LicenseKey
        {
            get { return _licenseKey; }
            set { _licenseKey = value; }
        }

        public int OrderId
        {
            get { return _commandId; }
            set { _commandId = value; }
        }

        public int DeliveryId
        {
            get { return _deliveryId; }
            set { _deliveryId = value; }
        }

        public string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
