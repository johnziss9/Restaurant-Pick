namespace Restaurant_Pick.DTOs.Restaurant
{
    public class UpdateRestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Bodeans";
        public string Cuisine { get; set; } = "BBQ";
        public string Location { get; set; } = "Soho";
        public bool Visited { get; set; } = false;
        public bool Deleted { get; set; } = false;
    }
}