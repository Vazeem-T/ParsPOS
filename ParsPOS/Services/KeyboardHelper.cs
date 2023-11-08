using ParsPOS.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID
using Android.Content;
using Android.Views.InputMethods;
#elif IOS
using UIKit;
#endif
namespace ParsPOS.Services
{
    public class KeyboardHelper : IkeyboardHelper
    {
        public void HideKeyboard()
        {
#if ANDROID
var context = Platform.AppContext;
            var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null)
            {
                var activity = Platform.CurrentActivity;
                var token = activity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);
                activity.Window.DecorView.ClearFocus();
            }

#elif IOS
            UIApplication.SharedApplication.Delegate.GetWindow().EndEditing(true);
#endif
        }
    }
}
