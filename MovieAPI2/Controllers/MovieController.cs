using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI2.Models;

namespace MovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieDB DB = new MovieDB();
        [Route ("GetAllMovies")]
        public Movie[] GetAllMovies()
        {
            return DB.Movies.ToArray();
        }
        [Route ("GetMoviesByCategory")]
        public Movie[] GetMoviesByCategory(string category)
        {
            return DB.Movies.Where (x => x.Category == category).ToArray();
        }
        [Route ("GetRandomMovie")]
        
        public Movie GetRandomMovie()
        {
            Random r = new Random();
            int rInt = r.Next(1, 10);

            Movie? randomMovie = null;
            foreach (Movie currMovie in DB.Movies)
            {     
                if (currMovie.Id == rInt)
                {
                    return currMovie;
                    break;           
                }
            }
            return null;

        }
        [Route ("GetRandomMovieInCategory")]
        public Movie GetRandomMovieInCategory(string category)
        {
            int categoryCount = DB.Movies.Where (x => x.Category == category).Count();
            Random r = new Random();
            int rInt = r.Next(1, categoryCount + 1);
            Movie? randomMovie = null;
            int i = 1;
            if (categoryCount > 0) 
            { 
                foreach (Movie currMovie in DB.Movies.Where(x => x.Category == category))
                {               
                    if (i == rInt)
                    {
                        randomMovie = currMovie;
                        break;
                    }
                    i++;
                }         
            }
            return randomMovie;
      

        }

    }
}
