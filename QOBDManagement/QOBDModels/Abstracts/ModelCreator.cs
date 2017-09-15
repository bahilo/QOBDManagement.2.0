using QOBDCommon.Exceptions;
using QOBDModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Abstracts
{
    public abstract class ModelCreator
    {

        public virtual object createModel(EModel modelName)
        {
            throw new NotApplicableException("Cannot create model for the targeted object!");
        }
    }
}
