using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseDTO;

namespace MovieDatabaseRepository
{
    public class MovieRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;

        public MovieRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieManager"));
        }

        public bool AddMovie(Movies movieToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                Movies existingItem = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingItem == null)
                {
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movies> TitleSearch(string title)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                List<Movies> titleSearch = db.Movies.Where(m => m.Title.ToLower().Contains(title)).ToList();
                return titleSearch;
            }
            
        }

        public List<Movies> GenreSearch(string genre)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                List<Movies> genreSearch = db.Movies.Where(m => m.Genre.ToLower().Contains(genre)).ToList();
                return genreSearch;
            }

        }
    }
}
