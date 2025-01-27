using System;

namespace Web.Models 
    public class ContactDetail
    {
        public int Id { get; set; }

        public string Value { get; set; }  
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
