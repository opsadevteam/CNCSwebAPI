using System;
using AutoMapper;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto.UserAccountsDtos;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Services.UserAccountService;

public class UserAccountService(IUserAccountRepository _userAccountRepository, IMapper mapper) : IUserAccountService
{
    public async Task<bool> AddAsync(UserAccountCreateDto userAccount)
    {
        return await _userAccountRepository.AddAsync(mapper.Map<TblUserAccount>(userAccount));
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userAccountRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserAccountListDto>> GetAllAsync()
    {
        var obj = await _userAccountRepository.GetAllAsync();
        return mapper.Map<IEnumerable<UserAccountListDto>>(obj);
    }

    public async Task<UserAccountGetAndUpdateDto?> GetAsync(int id)
    {
        var obj = await _userAccountRepository.GetAsync(id);
        return mapper.Map<UserAccountGetAndUpdateDto>(obj);
    }

    public async Task<bool> IsUserExistsAsync(string Username, int id)
    {
        return await _userAccountRepository.IsUserExistsAsync(Username, id);
    }
    public async Task<bool> UpdateDetailsAsync(int UserAccount_Id, UserAccountGetAndUpdateDto userAccount)
    {
        var obj = await _userAccountRepository.GetAsync(UserAccount_Id);

        if(obj is null) return false;

        obj.FullName = userAccount.FullName;
        obj.Username = userAccount.Username;
        obj.Password = userAccount.Password;
        obj.UserGroup = userAccount.UserGroup;
        obj.Status = userAccount.Status;

        return await _userAccountRepository.UpdateAsync(obj);
    }

    public async Task<bool> UpdatePasswordAsync(int UserAccount_Id, UserAccountChangePasswordDto userAccountChangePasswordDto)
    {
        var obj = await _userAccountRepository.GetAsync(UserAccount_Id);

        if(obj is null) return false;

        obj.Password = userAccountChangePasswordDto.NewPassword;

        return await _userAccountRepository.UpdateAsync(obj);
    }
}