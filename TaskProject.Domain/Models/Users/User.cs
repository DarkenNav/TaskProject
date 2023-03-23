namespace TaskProject.Domain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? ParentId { get; set; }
    }
}
