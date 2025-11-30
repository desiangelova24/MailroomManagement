namespace MailroomManagement.Api.Models.DTOs
{
    public class LetterDto
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateReceived { get; set; }
        public string AttachmentUrl { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string OrganizationName { get; set; }
    }
}
