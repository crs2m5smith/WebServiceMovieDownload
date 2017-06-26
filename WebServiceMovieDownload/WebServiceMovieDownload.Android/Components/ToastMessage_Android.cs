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
using WebServiceMovieDownload.Droid.Components;
using WebServiceMovieDownload.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage_Android))]

namespace WebServiceMovieDownload.Droid.Components
{
    public class ToastMessage_Android : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }

}