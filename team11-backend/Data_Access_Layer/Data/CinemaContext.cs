using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {   }
        public DbSet<Entities.Actor> Actors { get; set; }
        public DbSet<Entities.Booking> Bookings { get; set; }
        public DbSet<Entities.Director> Directors { get; set; }
        public DbSet<Entities.Genre> Genres { get; set; }
        public DbSet<Entities.Movie> Movies { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }
        public DbSet<Entities.SalesStatistics> SalesStatistics { get; set; }
        public DbSet<Entities.Session> Sessions { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Hall> Halls { get; set; }
        public DbSet<Entities.Seat> Seats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>()
            //    .HasMany(m => m.Actors)
            //    .WithMany(a => a.Movies)
            //    .UsingEntity<MovieActor>(
            //        am => am.HasOne<Actor>().WithMany(),
            //        am => am.HasOne<Movie>().WithMany(),
            //        am =>
            //        {
            //            am.HasKey(am => new { am.ActorId, am.MovieId });
            //            am.ToTable("MovieActors");
            //        });
            modelBuilder.Entity<MovieActor>()
                  .HasKey(ma => new { ma.MovieId, ma.ActorId }); // Composite key

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Cascade);



            //modelBuilder.Entity<Movie>()
            //    .HasMany(m => m.Genres)
            //    .WithMany(g => g.Movies)
            //    .UsingEntity<MovieGenre>(
            //        mg => mg.HasOne<Genre>().WithMany(),
            //        mg => mg.HasOne<Movie>().WithMany(),
            //        mg =>
            //        {
            //            mg.HasKey(mg => new { mg.GenreId, mg.MovieId });
            //            mg.ToTable("MovieGenres");
            //        });



            modelBuilder.Entity<MovieGenre>()
                  .HasKey(mg => new { mg.MovieId, mg.GenreId }); // Composite key
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Sessions)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Sessions)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<SalesStatistics>()
                .HasOne(ss => ss.Session)
                .WithMany(s => s.SalesStatistics)
                .HasForeignKey(ss => ss.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Seat)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SeatId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Booking>()
                .HasOne(s => s.Session)
                .WithMany(b => b.Bookings)
                .HasForeignKey(s => s.SessionId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Booking>()
                .HasOne(u => u.User)
                .WithMany(b => b.Bookings)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Seats)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
