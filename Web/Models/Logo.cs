namespace Web.Models
{
    public class Logo
    {
        public int Id { get; set; }

        // Marking all non-nullable properties as required
        public required string Name { get; set; }
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
