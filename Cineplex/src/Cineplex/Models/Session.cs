using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class Session
    {
        public Session()
        {
            BookedSeats = new HashSet<BookedSeats>();
            Booking = new HashSet<Booking>();
        }

        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public int CinemaId { get; set; }
        public int MovieId { get; set; }

        public virtual ICollection<BookedSeats> BookedSeats { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
