namespace Infrastructure.QueryModel;

public class BoxModelQuery
{
        public int Id { get; set; } // Unique identifier for the box
        public string? Title { get; set; } // User-friendly name or label
        public string? Type { get; set; } // Type or category of the box
        public string? Image { get; set; } // Image of the box
        public string? Status { get; set; } // Sold or not or damaged
        public decimal? Price { get; set; } // Price of the box
        public string? Color { get; set; } // Color of the box
        public string? Description { get; set; } // Description of the box
}