﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IQuoteViewModel
    {
        void loadQuotations();
        void Dispose();
    }
}
