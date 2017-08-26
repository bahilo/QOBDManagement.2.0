using QOBDCommon.Entities;
using QOBDModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Classes
{
    public class InfoContact: InfoBase
    {
        private Dictionary<string, Info> _contactDictionary;
        private List<Info> _infosList;

        public InfoContact(List<Info> infosList)
        {
            _infosList = new List<Info>();
            _contactDictionary = new Dictionary<string, Info>();
            _filter = new List<string> {
                    "company_name",         //=> nom_societe
                    "address",              //=> adresse
                    "phone",                //=> tel
                    "fax",                  //=> fax
                    "email",                //=> email
                    "tax_code",             //=> num_tva    
                };
            _contactDictionary = InfoGeneral.getInfoDictionary(infosList, _filter);
        }

        public Dictionary<string, Info> ContactDictionary
        {
            get { return _contactDictionary; }
            set { setProperty(ref _contactDictionary, value); }
        }

        public string TxtCompanyName
        {
            get { return (_contactDictionary.ContainsKey(_filter[0])) ? _contactDictionary[_filter[0]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[0]].Value = value; onPropertyChange("TxtCompanyName"); } }
        }

        public string TxtAddress
        {
            get { return (_contactDictionary.ContainsKey(_filter[1])) ? _contactDictionary[_filter[1]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[1]].Value = value; onPropertyChange("TxtAddress"); } }
        }

        public string TxtPhone
        {
            get { return (_contactDictionary.ContainsKey(_filter[2])) ? _contactDictionary[_filter[2]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[2]].Value = value; onPropertyChange("TxtPhone"); } }
        }

        public string TxtFax
        {
            get { return (_contactDictionary.ContainsKey(_filter[3])) ? _contactDictionary[_filter[3]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[3]].Value = value; onPropertyChange("TxtFax"); } }
        }

        public string TxtEmail
        {
            get { return (_contactDictionary.ContainsKey(_filter[4])) ? _contactDictionary[_filter[4]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[4]].Value = value; onPropertyChange("TxtEmail"); } }
        }

        public string TxtTaxCode
        {
            get { return (_contactDictionary.ContainsKey(_filter[5])) ? _contactDictionary[_filter[5]].Value : ""; }
            set { if (_contactDictionary.Count > 0) { _contactDictionary[_filter[5]].Value = value; onPropertyChange("TxtTaxCode"); } }
        }

        public List<Info> InfosList
        {
            get { return _infosList; }
            set { setProperty(ref _infosList, value, "InfosList"); }
        }
    }
}
