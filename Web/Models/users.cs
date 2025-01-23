namespace Web.Models
{
    public class User
    {
        public int Id { get; set; } // User Id (Primary Key)

        // Marking non-nullable properties as required
        public required string Username { get; set; } // Username for the user
        public required string Email { get; set; } // Email address of the user
        public required string PasswordHash { get; set; } // Hash of the user's password
        public required string CreatedBy { get; set; } // Example of required property for the creator

        // Nullable properties
        public string? Role { get; set; } // User role (Admin, User, etc.), can be null
        public DateTime? CreatedAt { get; set; } // Date and time when the user was created
        public DateTime? ModifiedAt { get; set; } // Date and time when the user was last modified
        public DateTime? DeletedAt { get; set; } // Date and time when the user was deleted (if applicable)
    }
}
