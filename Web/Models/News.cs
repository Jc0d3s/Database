namespace Web.Models
{
    public class News
    {
        public int Id { get; set; }

        // Marking all non-nullable properties as required
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public required string Link { get; set; }
        public required string Image { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
        public required string DeletedBy { get; set; }

        // Nullable properties
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
