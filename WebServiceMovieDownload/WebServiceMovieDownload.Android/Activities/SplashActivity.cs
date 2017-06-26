using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace WebServiceMovieDownload.Droid.Activities
{
    [Activity(Label = "WebServiceMovieDownload", Icon = "@drawable/icon", Theme = "@style/Theme.Splash",  MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}