using System;
using System.Collections.Generic;

namespace Cineplex.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int SessionId { get; set; }
        public string BookingType { get; set; }

        public virtual Session Session { get; set; }
    }
}
