using System;
using System.Collections.Generic;

#nullable disable

namespace RentMovies.Models
{
    public partial class PopularMovie
    {
        public int MovieId { get; set; }
        public string OriginalTitle { get; set; }
        public string Popularity { get; set; }
        public string VoteCount { get; set; }
        public string VoteAverage { get; set; }
        public string Title { get; set; }
    }
}
