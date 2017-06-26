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
using System.Net;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebServiceMovieDownload.Droid.Components.WebClient_Android))]

namespace WebServiceMovieDownload.Droid.Components
{
    public class WebClient_Android : IWebClient
    {
        public byte[] GetBytesFromUrl(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadData(url);
        }
    }
}