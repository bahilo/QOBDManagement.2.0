using QOBDModels.Abstracts;
using QOBDViewModels.Interfaces;
using System;

namespace QOBDViewModels.Classes
{
    public abstract class ViewModel : BindBase, IState
    {
        public void Handle(Context context, Func<object, object> page)
        {
            var prev = context.PreviousState;
            context.PreviousState = context.NextState;
            context.NextState = prev;
            page(context.NextState);
        }

        public virtual void load() { }
    }
}
