using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Globals
{
    public static class WebServiceEndPoints
    {
        public static string _basePoint ="https://api.themoviedb.org/3/movie/";
        public static string _endPoint = "{0}?api_key={1}&sort_by=popularity.des";
        public static string _posterPoint = "https://image.tmdb.org/t/p/w780/{0}";
        public static string _similarPoint = "{0}/similar?api_key={1}";
        public static string _moviePoint = "{0}?api_key={1}";

    }
}
