namespace MovieAPI2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public Movie(int id, string title, string category)
        {
            this.Id = id;
            this.Title = title;
            this.Category = category;

        }

        private static int NextId = 11;
    }
}
