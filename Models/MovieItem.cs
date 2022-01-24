namespace MovieAPI {
    public class MovieItem {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writers { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public int Rating { get; set; }
        public string Sinopsis { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Likes { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public MovieItem(int Id, string Title, string Writers, int Year, int Duration, int Rating, string Sinopsis, string Director, string Actors, int Likes, int CategoryId, int SubcategoryId) {
            this.Id = Id;
            this.Title = Title;
            this.Writers = Writers;
            this.Year = Year;
            this.Duration = Duration;
            this.Rating = Rating;
            this.Sinopsis = Sinopsis;
            this.Director = Director;
            this.Actors = Actors;
            this.Likes = Likes;
            this.CategoryId = CategoryId;
            this.SubcategoryId = SubcategoryId;
        }
    }
}