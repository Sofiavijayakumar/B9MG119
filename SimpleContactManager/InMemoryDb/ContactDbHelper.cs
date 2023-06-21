using Microsoft.AspNetCore.Razor.TagHelpers;
using SimpleContactManager.Models;

namespace SimpleContactManager.InMemoryDb
{
    public class ContactDbHelper : IDisposable
    {
        public ContactDbHelper() { 
        }
        public List<Contact> GetContacts()
        {
            using (var _context = new ContactDbContext())
            {
                var contacts = _context.Contacts.Select(e => new Contact
                {
                    Name = e.Name,
                    Id = e.Id,
                    AddressLine1 = e.AddressLine1,
                    AddressLine2 = e.AddressLine2,
                    City = e.City,
                    EmailAddress = e.EmailAddress,
                    MobileNumber = e.MobileNumber,
                }).ToList();
                return contacts;
            }
        }

        public Contact GetContact(int id)
        {
            using (var _context = new ContactDbContext())
            {
                var result = _context.Contacts.Where(e => e.Id == id).Select(e => new Contact
                {
                    Name = e.Name,
                    Id = e.Id,
                    AddressLine1 = e.AddressLine1,
                    AddressLine2 = e.AddressLine2,
                    City = e.City,
                    EmailAddress = e.EmailAddress,
                    MobileNumber = e.MobileNumber
                }).FirstOrDefault();
                return result;
            }
        }

        public Boolean Create(Contact contact)
        {
            using (var _context = new ContactDbContext())
            {
                ContactModel model = new ContactModel
                {
                    AddressLine1 = contact.AddressLine1,
                    AddressLine2 = contact.AddressLine2,
                    City = contact.City,
                    EmailAddress = contact.EmailAddress,
                    Id = contact.Id,
                    MobileNumber = contact.MobileNumber,
                    Name = contact.Name,
                };
                _context.Contacts.Add(model);
                _context.SaveChanges();
                return true;
            }
        }

        public Boolean Delete(int id)
        {
            using (var _context = new ContactDbContext())
            {
                var contact = _context.Contacts.Where(e => e.Id == id).FirstOrDefault();
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public void Dispose()
        {
            //Nothing to dispose
        }
    }
}
