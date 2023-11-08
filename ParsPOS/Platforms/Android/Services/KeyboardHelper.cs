using Android.Content;
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
            var context = Platform.AppContext;
            var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null)
            {
                var activity = Platform.CurrentActivity;
                var token = activity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);
                activity.Window.DecorView.ClearFocus();
            }
        }
    }
}
