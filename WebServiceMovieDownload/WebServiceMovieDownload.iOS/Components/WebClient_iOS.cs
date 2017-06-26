using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebServiceMovieDownload.iOS.Components.WebClient_iOS))]
namespace WebServiceMovieDownload.iOS.Components
{
    public class WebClient_iOS : IWebClient
    {
        public byte[] GetBytesFromUrl(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadData(url);
        }
    }
}
