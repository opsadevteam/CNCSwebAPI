using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Repository
{
    public class UserAccountRepository : IUserAccount
    {
        private readonly CncssystemContext _context;

        public UserAccountRepository(CncssystemContext context)
        {
            _context = context;
        }
        public bool CreateUserAccount(TblUserAccount userAccount)
        {
            _context.Add(userAccount);

            return Save();
        }

        public bool DeleteUserAccount(TblUserAccount userAccount)
        {
            _context.Remove(userAccount);

            return Save();
        }

        public TblUserAccount GetUserAccount(int id)
        {
            return _context.TblUserAccount.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<TblUserAccount> GetUserAccounts()
        {
            return _context.TblUserAccount.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUserAccount(TblUserAccount userAccount)
        {
            _context.Update(userAccount);
            return Save();
        }

        public bool UserAccountExists(int userAccountId)
        {
            return _context.TblUserAccount.Any(p => p.Id == userAccountId);
        }
    }
}
