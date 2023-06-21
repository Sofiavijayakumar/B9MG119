namespace SimpleContactManager.InMemoryDb
{
    public class ContactModel
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String City { get; set; }
        public String MobileNumber { get; set; }
        public String EmailAddress { get; set; }
    }
}
