namespace Restaurant_Pick.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public bool Visited { get; set; }
        public bool Deleted { get; set; }
    }
}