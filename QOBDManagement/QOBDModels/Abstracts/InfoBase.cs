using QOBDCommon.Entities;
using QOBDModels.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Abstracts
{
    public abstract class InfoBase : BindBase
    {
        protected string _password;
        protected string _login;
        protected List<string> _filter;
        protected List<Info> _infoList;
        protected Dictionary<string, Info> _dictionary;
        protected InfoGeneral _genralInfo;

        public InfoBase()
        {
            _password = "";
            _login = "";
            _filter = new List<string>();
            _dictionary = new Dictionary<string, Info>();
        }
    }
}
