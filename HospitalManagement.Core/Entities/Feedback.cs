namespace HospitalSystem.Core.Entities
{
    public class Feedback
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser  { get; set; }
        public string Comments { get; set; }
        public DateTime DateFeedback { get; set; } = DateTime.Now;






    }
}
