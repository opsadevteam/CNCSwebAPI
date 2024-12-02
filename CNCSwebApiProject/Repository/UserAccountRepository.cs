using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CNCSproject.Repository;

public class UserAccountRepository(CncssystemContext context) : IUserAccountRepository
{
    public async Task<IEnumerable<TblUserAccount>> GetAllAsync()
    {
        return await context.TblUserAccount
        .Where(user => user.IsDeleted == false)
        .OrderByDescending(user => user.Id)
        .ToListAsync();
    }

    public async Task<TblUserAccount?> GetAsync(int id)
    {
        return await context.TblUserAccount
        .Where(a => a.Id == id)
        .Where(a => a.IsDeleted == false)
        .SingleOrDefaultAsync();
    }

    public async Task<bool> AddAsync(TblUserAccount userAccount)
    {
        await context.TblUserAccount.AddAsync(userAccount);
        return await  SaveAllAsync();
    }

     public async Task<bool> UpdateAsync(TblUserAccount userAccount)
    {
        context.TblUserAccount.Update(userAccount);
        return await SaveAllAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await context.TblUserAccount
            .Where(a => a.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        return deleted > 0;
    }

    public async Task<bool> IsUserExistsAsync(string Username)
    {

        return await context.TblUserAccount
            .AnyAsync(x => x.Username!.ToLower() == Username.ToLower() && x.IsDeleted == false);
    }


    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
