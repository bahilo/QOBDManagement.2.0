using QOBDViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Classes
{
    public class Singleton
    {
        public static ConfirmationViewModel DialogBox;
        public static Cart Cart;

        private Singleton(){ }

        public static ConfirmationViewModel getDialogueBox()
        {
            object _lock = new object();
            if (DialogBox == null)
            {
                lock (_lock)
                {
                    if (DialogBox == null)
                        DialogBox = new ConfirmationViewModel();
                }
            }

            return DialogBox;
        }

        public static Cart getCart()
        {
            object _lock = new object();
            if (Cart == null)
            {
                lock (_lock)
                {
                    if (Cart == null)
                        Cart = new Cart();
                }
            }

            return Cart;
        }


    }
}
