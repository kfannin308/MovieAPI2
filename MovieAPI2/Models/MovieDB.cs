namespace MovieAPI2.Models
{
    public class MovieDB
    {
        public List<Movie> Movies { get; set; }

        public MovieDB()
        {
            Movies = new List<Movie>()
            {
                new Movie(1,"Gone with the Wind", "Drama"),
                new Movie(2,"Wizard of Oz", "Drama"),
                new Movie(3,"Bridesmades", "RomCom"),
                new Movie(4,"Top Gun","Action"),
                new Movie(5,"The Little Mermaid","Children"),
                new Movie(6,"Mission Impossible","Action"),
                new Movie(7,"Bambi","Children"),
                new Movie(8,"Christmas Vacation","Christmas"),
                new Movie(9,"Beauty and the Beast","Children"),
                new Movie(10, "Friday the 13th", "Thriller")
            };
        }
        
    }
}
