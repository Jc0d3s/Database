using Web.Models;

namespace Web.Handler
{
    public class ContactDetailsHandler
    {
        public interface IContactDetailsHandler
        {
            Task<IEnumerable<ContactDetail>> GetAllContactDetailsAsync();
            Task<ContactDetail> GetContactDetailByIdAsync(int id);
            Task AddContactDetailAsync(ContactDetail contactDetail);
            Task UpdateContactDetailAsync(ContactDetail contactDetail);
            Task DeleteContactDetailAsync(int id);
        }

        public class ContactDetailsHandler : IContactDetailsHandler
        {
            private readonly ContactDetailsRepository _repository;

            public ContactDetailsHandler(ContactDetailsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<ContactDetail>> GetAllContactDetailsAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<ContactDetail> GetContactDetailByIdAsync(int id)
            {
                var contactDetail = await _repository.GetByIdAsync(id);
                if (contactDetail == null)
                {
                    throw new KeyNotFoundException("Contact detail not found.");
                }
                return contactDetail;
            }

            public async Task AddContactDetailAsync(ContactDetail contactDetail)
            {
                contactDetail.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(contactDetail);
            }

            public async Task UpdateContactDetailAsync(ContactDetail contactDetail)
            {
                var existingContact = await _repository.GetByIdAsync(contactDetail.Id);
                if (existingContact == null)
                {
                    throw new KeyNotFoundException("Contact detail not found.");
                }
                existingContact.Value = contactDetail.Value;
                existingContact.ModifiedDate = DateTime.UtcNow;
                await _repository.UpdateAsync(existingContact);
            }

            public async Task DeleteContactDetailAsync(int id)
            {
                var existingContact = await _repository.GetByIdAsync(id);
                if (existingContact == null)
                {
                    throw new KeyNotFoundException("Contact detail not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
