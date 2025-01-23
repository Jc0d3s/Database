namespace Web.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        // Marking these properties as required to avoid null values
        public required string Name { get; set; } // Name is required
        public required string Position { get; set; } // Position is required
        public required string Quote { get; set; } // Quote is required
        public required string Image { get; set; } // Image is required

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }

        // Soft delete property
        public bool IsDeleted { get; set; }  // Add this property
        public DateTime? DeletedDate { get; set; } // Optional: track the deletion date
    }
}
