using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Interfaces
{
    public interface IWebClient
    {
        byte[] GetBytesFromUrl(string url);
    }
}
