using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class MovieResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string Tagline { get; set; }

    }
}
