using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Models
{

    public class MovieListResponseModel
    {
        [JsonProperty(PropertyName = "results")]
        public Result[] Results { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "dates")]
        public Dates _Dates { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        

        public class Dates
        {
            [JsonProperty(PropertyName = "maximum")]
            public string Maximum { get; set; }

            [JsonProperty(PropertyName = "minimum")]
            public string Minimum { get; set; }
        }

        public class Result
        {
            [JsonProperty(PropertyName = "vote_count")]
            public int VoteCount { get; set; }

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "video")]
            public bool Video { get; set; }

            [JsonProperty(PropertyName = "vote_average")]
            public float VoteAverage { get; set; }

            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "popularity")]
            public float Popularity { get; set; }

            [JsonProperty(PropertyName = "poster_path")]
            public string PosterPath { get; set; }

            [JsonProperty(PropertyName = "original_language")]
            public string OriginalLanguage { get; set; }

            [JsonProperty(PropertyName = "original_title")]
            public string OriginalTitle { get; set; }

            [JsonProperty(PropertyName = "genre_ids")]
            public int[] GenreIds { get; set; }

            [JsonProperty(PropertyName = "backdrop_path")]
            public string BackdropPath { get; set; }

            [JsonProperty(PropertyName = "adult")]
            public bool Adult { get; set; }

            [JsonProperty(PropertyName = "overview")]
            public string Overview { get; set; }

            [JsonProperty(PropertyName = "release_date")]
            public string ReleaseDate { get; set; }
        }

    }
}
