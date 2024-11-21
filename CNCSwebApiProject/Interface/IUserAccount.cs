using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IUserAccount
    {
        ICollection<TblUserAccount> GetUserAccounts();
        TblUserAccount GetUserAccount(int id);
        bool UserAccountExists(int userAccountId);
        bool CreateUserAccount(TblUserAccount userAccount);
        bool UpdateUserAccount(TblUserAccount userAccount);
        bool DeleteUserAccount(TblUserAccount userAccount);
        bool Save();
    }
}
