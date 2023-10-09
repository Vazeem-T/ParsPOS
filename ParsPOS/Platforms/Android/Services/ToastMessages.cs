
using Android.Widget;
using ParsPOS.Platforms.Android.Services;
using ParsPOS.Services;

using DependencyAttribute = Microsoft.Maui.Controls.DependencyAttribute;

[assembly: Dependency(typeof(ToastMessages))]
namespace ParsPOS.Platforms.Android.Services
{
    public class ToastMessages : IToast
    {
        public void ShortToast(string message)
        {
            //Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
        public void LongToast(string message)
        {
            //Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}
