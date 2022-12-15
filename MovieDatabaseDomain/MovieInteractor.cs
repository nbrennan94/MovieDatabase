using MovieDatabaseDTO;
using MovieDatabaseRepository;

namespace MovieDatabaseDomain
{
    public class MovieInteractor
    {
        private MovieRepository _repository;

        public MovieInteractor()
        {
            _repository = new MovieRepository();
        }

        public bool AddNewMovie(Movies movieToAdd)
        {
            if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
            {
                throw new ArgumentException("Name and Genre must contain valid text.");
            }
            return _repository.AddMovie(movieToAdd);

        }

        public List<Movies> SearchByTitle(string title)
        {
            return _repository.TitleSearch(title);
        }

        public List<Movies> SearchByGenre(string genre)
        {
            return _repository.GenreSearch(genre);
        }

    }
}