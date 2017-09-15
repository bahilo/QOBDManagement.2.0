using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDCommon.Exceptions
{
    public class NotApplicableException : Exception
    {
        public NotApplicableException()
        {

        }

        public NotApplicableException(string errorMessage)
            :base(errorMessage)
        { }

        public NotApplicableException(string errorMessage, Exception inner)
            : base(errorMessage, inner)
        { }
    }
}
