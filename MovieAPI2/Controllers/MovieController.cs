using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI2.Models;
using System.Collections.Generic;

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
        [Route("GetRandomMoviePicks")]
        public Movie[] GetRandomMoviePicks(int pickNum)
        {
            int movieCount = 0;
            Random rdn = new Random();
            int rInt;
            List<Movie> pickList = new List<Movie>();
            bool inList;
            if (pickNum > 0)
            {
                do
                {
                    rInt = rdn.Next(0, DB.Movies.Count);
                    inList = pickList.Contains(DB.Movies[rInt]);
                    if (!inList)
                    {
                        pickList.Add(DB.Movies[rInt]);
                        movieCount++;
                    }
                    
                    

                    /*
                     * rInt = rdn.Next(1, DB.Movies.Count + 1);
                    for (int i = 0; i < DB.Movies.Count; i++)   
                        {

                            if (i == rInt)
                            {
                                pickList.Add(DB.Movies[i]);
                                movieCount++;
                                if (movieCount == pickNum) { break; }
                            }
                        }  
                    } */
                }
                while (movieCount < pickNum);
            }
            return pickList.ToArray();
        }
    }
}
