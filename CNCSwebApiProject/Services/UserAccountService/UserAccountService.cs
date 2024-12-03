using System;
using AutoMapper;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.UserAccountService;

public class UserAccountService(IUserAccountRepository _userAccountRepository, IMapper mapper) : IUserAccountService
{
    public async Task<bool> AddAsync(UserAccountUpsertDto userAccount)
    {
        return await _userAccountRepository.AddAsync(mapper.Map<TblUserAccount>(userAccount));
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userAccountRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserAccountGetDto>> GetAllAsync()
    {
        var obj = await _userAccountRepository.GetAllAsync();
        return mapper.Map<IEnumerable<UserAccountGetDto>>(obj);
    }

    public async Task<UserAccountGetDto?> GetAsync(int id)
    {
        var obj = await _userAccountRepository.GetAsync(id);
        return mapper.Map<UserAccountGetDto>(obj);
    }

    public async Task<bool> IsUserExistsAsync(string Username, int id)
    {
        return await _userAccountRepository.IsUserExistsAsync(Username, id);
    }
    public async Task<bool> UpdateAsync(UserAccountUpsertDto userAccount)
    {
        return await _userAccountRepository.UpdateAsync(mapper.Map<TblUserAccount>(userAccount));
    }
}
