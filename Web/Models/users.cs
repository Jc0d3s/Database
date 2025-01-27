namespace Web.Models
{
    public class User
    {
        public int Id { get; set; } 

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; } 
        public required string CreatedBy { get; set; } 

        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }  
    }
}
