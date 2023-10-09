using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public abstract class BaseViewModel : IViewModel
    {
        public BaseViewModel() { }
        public abstract Task Initialize();
        public abstract Task Stop();
    }
    public interface IViewModel
    {
        Task Initialize();
        Task Stop();
    }
}
