namespace MailroomManagement.Api.Models.Responses.Letters
{
    public class LetterResponse
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateReceived { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
