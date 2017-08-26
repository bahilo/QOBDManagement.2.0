using QOBDCommon.Entities;
using QOBDModels.Abstracts;
using System;

namespace QOBDModels.Models
{
    public class InfosModel : BindBase
    {
        private Info _infos;

        public InfosModel()
        {
            _infos = new Info();
        }

        public string TxtID
        {
            get { return _infos.ID.ToString(); }
            set { _infos.ID = Convert.ToInt32(value); onPropertyChange("TxtID"); }
        }

        public string TxtName
        {
            get { return _infos.Name; }
            set { _infos.Name = value; onPropertyChange("TxtName"); }
        }

        public string TxtValue
        {
            get { return _infos.Value; }
            set { _infos.Value = value; onPropertyChange("TxtValue"); }
        }

    }
}
