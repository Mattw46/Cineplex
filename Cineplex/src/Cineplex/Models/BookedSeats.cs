using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class BookedSeats
    {
        public int SessionId { get; set; }
        public int SeatNumber { get; set; }

        public virtual Session Session { get; set; }
    }
}
