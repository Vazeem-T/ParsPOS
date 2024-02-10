using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using ParsVanSale.Services;
using Button = Android.Widget.Button;
using View = Android.Views.View;

namespace ParsVanSale.Platforms.Android.Custom
{
	internal class CustomShellItemRenderer : ShellItemRenderer
	{
		public CustomShellItemRenderer(IShellContext context) : base(context)
		{
		}

	}
}
