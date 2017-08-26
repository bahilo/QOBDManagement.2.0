using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QOBDModels.Abstracts
{
    public class BindBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;        
        
        public virtual void setProperty<P>(
            ref P member,
            P val,
            [CallerMemberName]
            string propertyName = null)
        {
            /*if (object.Equals(member,val))
                return;*/

            member = val;
            
            onPropertyChange(propertyName);
        }
        
        public void onPropertyChange([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }                
        }

        public virtual void Dispose()
        {
            
        }


    }
}
