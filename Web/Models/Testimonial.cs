namespace Web.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        public required string Name { get; set; } 
        public required string Position { get; set; }
        public required string Quote { get; set; } 
        public required string Image { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }  
        public DateTime? DeletedDate { get; set; } 
}
