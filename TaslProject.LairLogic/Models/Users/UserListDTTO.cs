namespace TaskProject.LairLogic.Models.Users
{
    public class UserListDTTO
    {
        public List<UserDTO> Users { get; set; }

        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
