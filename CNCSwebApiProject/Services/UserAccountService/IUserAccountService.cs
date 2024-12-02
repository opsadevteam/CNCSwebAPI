using System;
using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.UserAccountService;

public interface IUserAccountService
{
    Task<IEnumerable<UserAccountDisplayDto>> GetAllAsync(); //get all user account
    Task<UserAccountDisplayDto?> GetAsync(int id); //get single user account
    Task<bool> AddAsync(UserAccountUpsertDto userAccount); // Add new user account
    Task<bool> UpdateAsync(UserAccountUpsertDto userAccount); // Update existing user account
    Task<bool> DeleteAsync(int id); // Delete user account by ID
    Task<bool> IsUserExistsAsync(string Username);
}
