using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public string BackgroundImagePath { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int DirectorId { get; set; }

        public List<int> Genres { get; set; }
        public List<int> Actors { get; set; }
    }

}
