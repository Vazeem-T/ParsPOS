using Android.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using ParsPOS.Platforms.Android.Services;
using Microsoft.Maui.Controls.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace ParsPOS.Platforms.Android.Services
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }
        protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        {
            return new CustomToolbarAppearanceTracker(this);
        }

        private class CustomToolbarAppearanceTracker : ShellToolbarAppearanceTracker
        {
            public CustomToolbarAppearanceTracker(IShellContext shellContext) : base(shellContext)
            {
            }

            public override void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
            {
                base.SetAppearance(toolbar, toolbarTracker, appearance);

                // Set the back button color here
            }
        }
    }
   
}
