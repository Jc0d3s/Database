namespace Web.Models
{
    public class Navbar
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? CreatedBy { get; set; }
        public int? EditedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
