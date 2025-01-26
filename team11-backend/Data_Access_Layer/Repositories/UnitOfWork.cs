using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly CinemaContext context;

        // Repositories for each entity
        private GenericRepository<Actor> actorRepository;
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Booking> bookingRepository;
        private GenericRepository<Director> directorRepository;
        private GenericRepository<Genre> genreRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<SalesStatistics> salesStatisticsRepository;
        private GenericRepository<Session> sessionRepository;
        private GenericRepository<User> userRepository;

        // Inject CinemaContext via constructor
        public UnitOfWork(CinemaContext context)
        {
            this.context = context;
        }

        // Properties for accessing repositories
        public GenericRepository<Actor> ActorRepository
        {
            get
            {
                if (this.actorRepository == null)
                {
                    this.actorRepository = new GenericRepository<Actor>(context);
                }
                return actorRepository;
            }
        }

        public GenericRepository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        // Repeat this pattern for all other entities...
        public GenericRepository<Booking> BookingRepository
        {
            get
            {
                if (this.bookingRepository == null)
                {
                    this.bookingRepository = new GenericRepository<Booking>(context);
                }
                return bookingRepository;
            }
        }

        public GenericRepository<Director> DirectorRepository
        {
            get
            {
                if (this.directorRepository == null)
                {
                    this.directorRepository = new GenericRepository<Director>(context);
                }
                return directorRepository;
            }
        }

        public GenericRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(context);
                }
                return roleRepository;
            }
        }

        public GenericRepository<SalesStatistics> SalesStatisticsRepository
        {
            get
            {
                if (this.salesStatisticsRepository == null)
                {
                    this.salesStatisticsRepository = new GenericRepository<SalesStatistics>(context);
                }
                return salesStatisticsRepository;
            }
        }

        public GenericRepository<Session> SessionRepository
        {
            get
            {
                if (this.sessionRepository == null)
                {
                    this.sessionRepository = new GenericRepository<Session>(context);
                }
                return sessionRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        // Save changes to the database
        public void Save()
        {
            context.SaveChanges();
        }

        // Dispose pattern
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
