using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class Movie
    {
        public Movie()
        {
            CinemaMovie = new HashSet<CinemaMovie>();
            Session = new HashSet<Session>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CinemaMovie> CinemaMovie { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
