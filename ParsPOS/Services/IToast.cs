using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public interface IToast
    {
        void ShortToast(string message);
        void LongToast(string message);
    }
}
