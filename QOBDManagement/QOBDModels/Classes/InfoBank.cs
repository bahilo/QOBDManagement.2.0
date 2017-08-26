using QOBDCommon.Entities;
using QOBDModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Classes
{
    public class InfoBank : InfoBase
    {
        private List<string> _bankfilterList;
        private Dictionary<string, Info> _bankDictionary;
        private List<Info> _infosList;

        public InfoBank(List<Info> infosList)
        {
            _infosList = new List<Info>();
            _bankfilterList = new List<string> {
                    "sort_code",                //=> code_banque
                    "account_number",           //=> num_compte
                    "acount_key_number",        //=> cle_rib
                    "bank_name",                //=> nom_banque
                    "branch_code",              //=> guichet
                    "iban",                     //=> IBAN
                    "bic",                      //=> BIC  
                    "bank_address",             //=> adresse_banque     
                };
            _bankDictionary = InfoGeneral.getInfoDictionary(infosList, _bankfilterList);

        }

        public List<Info> InfosList
        {
            get { return _infosList; }
            set { setProperty(ref _infosList, value, "InfosList"); }
        }

        public Dictionary<string, Info> BankDictionary
        {
            get { return _bankDictionary; }
            set { setProperty(ref _bankDictionary, value); }
        }

        public string TxtSortCode
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[0])) ? _bankDictionary[_bankfilterList[0]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[0])) { _bankDictionary[_bankfilterList[0]].Value = value; onPropertyChange("TxtSortCode"); } }
        }

        public string TxtAccountNumber
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[1])) ? _bankDictionary[_bankfilterList[1]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[1])) { _bankDictionary[_bankfilterList[1]].Value = value; onPropertyChange("TxtAccountNumber"); } }
        }

        public string TxtAccountKeyNumber
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[2])) ? _bankDictionary[_bankfilterList[2]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[2])) { _bankDictionary[_bankfilterList[2]].Value = value; onPropertyChange("TxtAccountKeyNumber"); } }
        }

        public string TxtBankName
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[3])) ? _bankDictionary[_bankfilterList[3]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[3])) { _bankDictionary[_bankfilterList[3]].Value = value; onPropertyChange("TxtBankName"); } }
        }

        public string TxtAgencyCode
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[4])) ? _bankDictionary[_bankfilterList[4]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[4])) { _bankDictionary[_bankfilterList[4]].Value = value; onPropertyChange("TxtAgencyCode"); } }
        }

        public string TxtIBAN
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[5])) ? _bankDictionary[_bankfilterList[5]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[5])) { _bankDictionary[_bankfilterList[5]].Value = value; onPropertyChange("TxtIBAN"); } }
        }

        public string TxtBIC
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[6])) ? _bankDictionary[_bankfilterList[6]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[6])) { _bankDictionary[_bankfilterList[6]].Value = value; onPropertyChange("TxtBIC"); } }
        }

        public string TxtBankAddress
        {
            get { return (_bankDictionary.ContainsKey(_bankfilterList[7])) ? _bankDictionary[_bankfilterList[7]].Value : ""; }
            set { if (_bankDictionary.ContainsKey(_bankfilterList[7])) { _bankDictionary[_bankfilterList[7]].Value = value; onPropertyChange("TxtBankAddress"); } }
        }
    }
}
