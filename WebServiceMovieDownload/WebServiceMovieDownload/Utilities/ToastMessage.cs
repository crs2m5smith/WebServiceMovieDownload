using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Utilities
{
    public static class ToastMessage
    {
        public static void ShortMessage(string message)
        {
            DependencyService.Get<IMessage>().ShortAlert(message);
        }

        public static void LongMessage(string message)
        {
            DependencyService.Get<IMessage>().LongAlert(message);
        }
    }

}
