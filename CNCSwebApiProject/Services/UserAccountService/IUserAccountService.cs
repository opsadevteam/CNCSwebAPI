using System;
using CNCSwebApiProject.Dto;

namespace CNCSwebApiProject.Services.UserAccountService;

public interface IUserAccountService
{
    Task<IEnumerable<UserAccountListDto>> GetAllAsync(); //get all user account
    Task<UserAccountGetAndUpdateDto?> GetAsync(int id); //get single user account
    Task<bool> AddAsync(UserAccountCreateDto userAccount); // Add new user account
    Task<bool> UpdateDetailsAsync(UserAccountGetAndUpdateDto userAccount); // Update existing user account
    Task<bool> UpdatePasswordAsync(UserAccountChangePasswordDto userAccountChangePasswordDto);
    Task<bool> DeleteAsync(int id); // Delete user account by ID
    Task<bool> IsUserExistsAsync(string Username, int id);
}
