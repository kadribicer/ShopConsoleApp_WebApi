namespace Shop.ConsoleApp.Entities
{
    public class User
    {
        private readonly UserType _type;
        private readonly DateTime _joinDate;

        public User(UserType type, DateTime joinDate)
        {
            _type = type;
            _joinDate = joinDate;
        }

        public UserType GetUserType() => _type;
        public DateTime GetJoinDate() => _joinDate;
    }
}