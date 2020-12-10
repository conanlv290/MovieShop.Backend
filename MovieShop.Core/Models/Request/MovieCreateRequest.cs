using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models
{
    public class MovieCreateRequest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(2084)]
        public string Overview { get; set; }
        [MaxLength(2084)]
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        [Required]
        public string PosterUrl { get; set; }
        [Required]
        public string BackDropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime RealaseDate { get; set; }
        public int RunTime { get; set; }
        public decimal? price { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
