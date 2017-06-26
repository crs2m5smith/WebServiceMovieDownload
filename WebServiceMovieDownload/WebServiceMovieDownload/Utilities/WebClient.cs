using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Utilities
{
    public static class WebClient
    {
        public static byte[] BytesFromUrl(string url)
        {
            return DependencyService.Get<IWebClient>().GetBytesFromUrl(url);
        }
    }
}
