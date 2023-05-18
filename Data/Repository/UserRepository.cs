using backend.Data.Entities;

namespace backend.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public User? GetUserByPhone(string phone)
        {
            return _context.Users.FirstOrDefault(u => u.Phone == phone);
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }

    }
}