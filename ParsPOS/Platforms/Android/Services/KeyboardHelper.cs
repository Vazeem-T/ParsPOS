using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using ParsPOS.InterfaceServices;
using ParsPOS.Platforms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly:Dependency(typeof(KeyboardHelper))]
namespace ParsPOS.Platforms.Services
{
    public class KeyboardHelper : IkeyboardHelper
    {
        public void HideKeyboard()
        {
            
            var activity = Platform.CurrentActivity as MainActivity;

            if (activity != null)
            {
                activity.Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);
            }
        }
    }
}
