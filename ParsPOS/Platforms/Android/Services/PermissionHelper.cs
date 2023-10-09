using Android;
using Android.App;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Platforms.Android.Services
{
    public static class PermissionHelper
    {
        public const int RequestStoragePermissionCode = 1; // Make it public or internal

        public static bool IsStoragePermissionGranted(Activity activity)
        {
            return ContextCompat.CheckSelfPermission(activity, Manifest.Permission.WriteExternalStorage) == Permission.Granted;
        }

        public static void RequestStoragePermission(Activity activity)
        {
            ActivityCompat.RequestPermissions(activity, new string[] { Manifest.Permission.WriteExternalStorage }, RequestStoragePermissionCode);
        }
    }
}
