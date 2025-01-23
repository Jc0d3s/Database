namespace Web.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
