using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cineplex.Models
{
    public partial class CineplexContext : DbContext
    {
        public virtual DbSet<BookedSeats> BookedSeats { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Enquiry> Enquiry { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Session> Session { get; set; }

        public CineplexContext(DbContextOptions<CineplexContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cineplex;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookedSeats>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.SeatNumber })
                    .HasName("PK__BookedSe__D7164EC0BE453BDF");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.BookedSeats)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__BookedSea__Sessi__300424B4");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingType).IsRequired();

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Booking__Session__2D27B809");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.LongDescription).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();
            });

            modelBuilder.Entity<Enquiry>(entity =>
            {
                entity.Property(e => e.EnquiryId).HasColumnName("EnquiryID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Message).IsRequired();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.LongDescription).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.SessionDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.CinemaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Session__CinemaI__29572725");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Session__MovieID__2A4B4B5E");
            });
        }
    }
}