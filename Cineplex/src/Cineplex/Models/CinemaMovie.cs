using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class CinemaMovie
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
