using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    [INotifyPropertyChanged]
    public partial class CategoryViewModel : BaseViewModel
    {
        public CategoryViewModel() 
        {

        }
        public override Task Initialize()
        {
            return Task.CompletedTask;
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
