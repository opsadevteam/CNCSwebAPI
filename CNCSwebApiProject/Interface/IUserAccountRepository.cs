using System;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;

namespace CNCSproject.Interface;

public interface IUserAccountRepository
{
    Task<IEnumerable<TblUserAccount>> GetAllAsync(); //get all user account
    Task<TblUserAccount?> GetAsync(int id); //get single user account
    Task<bool> AddAsync(TblUserAccount userAccount); // Add new user account
    Task<bool> UpdateAsync(TblUserAccount userAccount); // Update existing user account
    Task<bool> DeleteAsync(int id); // Delete user account by ID
    Task<bool> SaveAllAsync(); // Save changes to the database
    Task<bool> IsUserExistsAsync(string Username, int id);
}
