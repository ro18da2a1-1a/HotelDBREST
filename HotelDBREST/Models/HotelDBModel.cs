namespace HotelDBREST.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDBModel : DbContext
    {
        public HotelDBModel()
            : base("name=HotelDBModel")
        {
        }

        public virtual DbSet<DemoBooking> DemoBookings { get; set; }
        public virtual DbSet<DemoGuest> DemoGuests { get; set; }
        public virtual DbSet<DemoHotel> DemoHotels { get; set; }
        public virtual DbSet<DemoRoom> DemoRooms { get; set; }
        public virtual DbSet<GuestAtPrindsen> GuestAtPrindsens { get; set; }
        public virtual DbSet<GuestAtPrindsen2> GuestAtPrindsen2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemoGuest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DemoGuest>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<DemoGuest>()
                .HasMany(e => e.DemoBookings);
                //.WithRequired(e => e.DemoGuest)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoHotel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DemoHotel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<DemoHotel>()
                .HasMany(e => e.DemoRooms);
                //.WithRequired(e => e.DemoHotel)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<DemoRoom>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DemoRoom>()
                .HasMany(e => e.DemoBookings);
                //.WithRequired(e => e.DemoRoom)
                //.HasForeignKey(e => new { e.Room_No, e.Hotel_No })
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<GuestAtPrindsen>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GuestAtPrindsen>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<GuestAtPrindsen2>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GuestAtPrindsen2>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
