using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public ImageSource ImageSource { get; set; }
        public string Overview { get; set; }
        public bool Adult { get; set; }
        public string AdultMovie { get; set; }
        public float Popularity { get; set; }
        public int VoteCount { get; set; }
        public float VoteAverage { get; set; }

    }
}
