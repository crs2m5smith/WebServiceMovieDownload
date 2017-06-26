using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Utilities
{
    public static class ImageResize
    {
        public static byte[] ImageResizer(byte[] imageArray, float width, float height)
        {
            return DependencyService.Get<IImageResizer>().ResizeImage(imageArray, width, height);
        }

    }
}
