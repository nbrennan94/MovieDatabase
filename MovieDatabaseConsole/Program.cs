using MovieDatabaseDomain;
using MovieDatabaseDTO;

MovieInteractor _movieInteractor = new MovieInteractor();

//LoadStartUpData();

bool movieSearch = true;
string title = "";
string genre = "";

Console.WriteLine("Welcome to the Brennan Home Video Store. We offer a variety of options for your movie viewing pleasure.");

while (movieSearch)
{
    Console.WriteLine("Would you like to search for a movie by title or by genre?");

    while (true)
    {
        string userChoice = Console.ReadLine().ToLower();

        if (userChoice == "title")
        {
            Console.WriteLine("Enter the title that you would like to look up.");
            title = Console.ReadLine().ToLower().Trim();
            DisplayTitleSearch();
            break;

        }

        else if (userChoice == "genre")
        {
            Console.WriteLine("Enter the genre that you would like to look up.");
            genre = Console.ReadLine().ToLower().Trim();
            DisplayGenreSearch();
            break;
        }

        else
        {
            Console.WriteLine("Sorry, that is not an option. Please, enter genre or title.");
        }
    }

    while (true)
    {
        Console.WriteLine("Would you like to search for another movie? Enter y or n.");
        string searchAgain = Console.ReadLine().ToLower().Trim();
        if (searchAgain == "y")
        {
            break;
        }
        else if (searchAgain == "n")
        {
            movieSearch = false;
            break;
        }
        else
        {
            Console.WriteLine("That is not a valid response. Please enter y or n.");
        }
    }


}

Console.WriteLine("Thank you for stopping by the Brennan Home Video Store. We hope to see you again!");
Console.ReadKey();



void DisplayTitleSearch()
{
    Console.WriteLine();
    Console.WriteLine($"Searching for title now...");

    foreach (Movies movie in _movieInteractor.SearchByTitle(title))
    {
        Console.WriteLine($"{movie.Title} is a {movie.Genre} film.");
    }
}

void DisplayGenreSearch()
{
    Console.WriteLine();
    Console.WriteLine($"Searching for genre now...");

    foreach (Movies movie in _movieInteractor.SearchByGenre(genre))
    {
        Console.WriteLine($"{movie.Title} is a {movie.Genre} film.");
    }
}

void LoadStartUpData()
{
    foreach (Movies movie in BuildMovieCollection())
    {
        if (_movieInteractor.AddNewMovie(movie) == true)
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}

List<Movies> BuildMovieCollection()
{
    List<Movies> initialMovies = new List<Movies>();
    initialMovies.Add(new Movies() { Title = "13 Going on 30", Genre = "Romantic Comedy", Runtime = 1.38 });
    initialMovies.Add(new Movies() { Title = "22 Jump Street", Genre = "Comedy", Runtime = 1.52 });
    initialMovies.Add(new Movies() { Title = "Crazy Stupid Love", Genre = "Romantic Comedy", Runtime = 1.58 });
    initialMovies.Add(new Movies() { Title = "Game Night", Genre = "Comedy", Runtime = 1.33 });
    initialMovies.Add(new Movies() { Title = "Jurassic Park", Genre = "Sci-Fi", Runtime = 2.07 });
    initialMovies.Add(new Movies() { Title = "Knives Out", Genre = "Mystery", Runtime = 2.10 });
    initialMovies.Add(new Movies() { Title = "Lilo & Stitch", Genre = "Animation", Runtime = 1.25 });
    initialMovies.Add(new Movies() { Title = "The Lion King", Genre = "Animation", Runtime = 1.29 });
    initialMovies.Add(new Movies() { Title = "The Lost City", Genre = "Action-Adventure", Runtime = 1.52 });
    initialMovies.Add(new Movies() { Title = "Monsters, Inc.", Genre = "Animation", Runtime = 1.36 });
    initialMovies.Add(new Movies() { Title = "Palm Springs", Genre = "Romantic Comedy", Runtime = 1.30 });
    initialMovies.Add(new Movies() { Title = "The Princess Bride", Genre = "Fantasy", Runtime = 1.38 });
    initialMovies.Add(new Movies() { Title = "Stick It", Genre = "Comedy", Runtime = 1.43 });
    initialMovies.Add(new Movies() { Title = "Top Gun: Maverick", Genre = "Action-Drama", Runtime = 2.11 });
    initialMovies.Add(new Movies() { Title = "Toy Story", Genre = "Animation", Runtime = 1.21 });
    return initialMovies;
}