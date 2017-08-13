using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Session = new HashSet<Session>();
        }

        public int CinemaId { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Session> Session { get; set; }
    }
}
