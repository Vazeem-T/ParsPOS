﻿using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using CommunityToolkit.Maui.Core;
using Android.Runtime;
using Android.Widget;
using ParsPOS.DBHandler;
using CommunityToolkit.Maui.Core.Platform;
using Android.Views.InputMethods;

namespace ParsPOS;

[Activity(Label = "PARSPOS", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);
        //Xamarin.KeyboardHelper.Platform.Droid.Effects.Init(this);
        CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(Colors.White);
        CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(StatusBarStyle.DarkContent);


    }
}
