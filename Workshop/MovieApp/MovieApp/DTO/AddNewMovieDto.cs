using MovieApp.Models.Enums;

namespace MovieApp.DTO
{
    public class AddNewMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
