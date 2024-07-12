namespace Phone.Entities
{
    public class MailAddress_
    {
        public string mailAddress { get; set; } = String.Empty;
        public string body { get; set; } = String.Empty;
        public bool isMailCC { get; set; } = false;
        public bool isMailBCC { get; set; } = false;
        public string subject { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }
}
