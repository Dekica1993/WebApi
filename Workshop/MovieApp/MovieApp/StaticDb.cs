using MovieApp.Models;
using MovieApp.Models.Enums;

namespace MovieApp
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie
            {
                Title = "Interstelar",
                Description = "Excellent Movie",
                Year = 2015,
                Genre = Genre.Triller
            },
            new Movie
            {
                Title = "Oppenheimer",
                Description = "Blow Mind",
                Year = 2023,
                Genre = Genre.Triller
            },
            new Movie
            {
                Title = "Bad Boys",
                Description = "Stunning",
                Year = 2005,
                Genre = Genre.Action
            },
            new Movie
            {
                Title = "Dumb and Dumber",
                Description = "Psihollogic",
                Year = 2007,
                Genre = Genre.Comedy
            }

        };
    }
}
