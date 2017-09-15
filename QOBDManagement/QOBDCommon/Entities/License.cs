using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDCommon.Entities
{
    public class License
    {
        public int ID { get; set; }

        public string AppVersion { get; set; }

        public string CompanyName { get; set; }

        public string Key { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public DateTime EndDate { get; set; }
    }
}
