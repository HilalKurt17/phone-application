namespace Phone.Entities
{
    public class Contacts
    {
        public Guid contactId { get; set; }
        public Guid userId { get; set; }

        public string contactName { get; set; }

        public string? contactSurname { get; set; }

        public string? phoneHome { get; set; }

        public string mobile { get; set; }

        public string? mobile2 { get; set; }

        public string? mobile3 { get; set; }

        public string? phoneWork { get; set; }

        public DateTime? birthday { get; set; }

        public DateTime? anniversary { get; set; }

        public string? email { get; set; }

        public string? _address { get; set; }



        public override string ToString()
        {
            return $"{contactName} {contactSurname}";
        }

    }
}
