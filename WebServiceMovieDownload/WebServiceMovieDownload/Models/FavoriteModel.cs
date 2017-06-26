using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Models
{
    public class FavoriteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public DateTime Date { get; set; }

        public string PosterPath { get; set; }

        public string Overview { get; set; }

        public string Title { get; set; }

    }
}
