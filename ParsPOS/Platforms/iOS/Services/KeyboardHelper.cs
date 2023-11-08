using ParsPOS.InterfaceServices;
using ParsPOS.Platforms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

[assembly: Dependency(typeof(KeyboardHelper))]
namespace ParsPOS.Platforms.Services
{
    public class KeyboardHelper : IkeyboardHelper
    {
        public void HideKeyboard()
        {
            UIApplication.SharedApplication.Delegate.GetWindow().EndEditing(true);
        }
    }
}
