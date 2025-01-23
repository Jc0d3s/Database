using System;

namespace Web.Models  // Assuming you're placing it in the 'Models' folder
{
    public class ContactDetail
    {
        // Unique identifier for ContactDetail (Primary Key)
        public int Id { get; set; }

        // Value of the contact detail (could be email, phone, etc.)
        public string Value { get; set; }  // Made non-nullable for simplicity, adjust as per your use case

        // Date when the contact detail was created
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Name of the person who created the contact detail
        public string CreatedBy { get; set; }

        // Date when the contact detail was last modified
        public DateTime? ModifiedDate { get; set; }

        // Name of the person who modified the contact detail
        public string ModifiedBy { get; set; }

        // Date when the contact detail was deleted
        public DateTime? DeletedDate { get; set; }

        // Name of the person who deleted the contact detail
        public string DeletedBy { get; set; }

        // Indicates whether the contact detail is logically deleted
        public bool IsDeleted { get; set; } = false;
    }
}
