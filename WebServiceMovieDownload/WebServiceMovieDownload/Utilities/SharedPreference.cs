using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Utilities
{
    public class SharedPreference
    {
        public static readonly ISharedPreference prefs;
        static SharedPreference()
        {
            prefs = DependencyService.Get<ISharedPreference>();
        }



    }
}
