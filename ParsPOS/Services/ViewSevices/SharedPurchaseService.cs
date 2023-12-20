using ParsPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services.ViewSevices
{
    public class SharedPurchaseService
    {
        public event EventHandler<Invitm> ItemSelected;
        public void Onselected(Invitm selectedItem)
        {
            ItemSelected?.Invoke(this, selectedItem);
        }
    }
}
