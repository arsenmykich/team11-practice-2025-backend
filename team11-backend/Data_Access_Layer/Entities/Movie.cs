using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    internal class Movie
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public string BackgroundImagePath { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}
