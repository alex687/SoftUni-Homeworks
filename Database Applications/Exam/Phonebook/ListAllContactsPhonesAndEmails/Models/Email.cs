namespace ListAllContactsPhonesAndEmails.Models
{
    public class Email
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public virtual Contact Contact { get; set; }
    }
}