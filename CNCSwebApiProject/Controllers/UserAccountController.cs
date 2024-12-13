﻿using Microsoft.AspNetCore.Cors;
using AutoMapper;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CNCSwebApiProject.Controllers;

[EnableCors("AllowOrigin")]
[Route("api/v1/[controller]")]
[ApiController]
public class UserAccountController(IUserAccountRepository _userAccountRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAccountDto>>> GetUserAccountsAsync()
    {
        var userDtoList = mapper.Map<List<UserAccountDto>>(await _userAccountRepository.GetAllAsync());

        return userDtoList.Any() ?
            Ok(userDtoList) :
            NotFound("No user accounts found.");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserAccountDto>> GetUserAccountAsync(int id)
    {
        var userDto = mapper.Map<UserAccountDto>(await _userAccountRepository.GetAsync(id));

        return userDto is not null ?
            Ok(userDto) :
            NotFound($"User with ID {id} not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAccountAsync(TblUserAccount newUser)
    {
        if (newUser is null) 
            return BadRequest("Invalid user account data.");

            if (await _userAccountRepository.IsUserExistsAsync(newUser.Username!))
                return Conflict("Username is already taken.");

        var isAdded = await _userAccountRepository.AddAsync(newUser);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding user account.");
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAccountAsync(int id, TblUserAccount userAccount)
    {
        if (id != userAccount.Id)
            return BadRequest("User ID mismatch.");

        if (await _userAccountRepository.IsUserExistsAsync(userAccount.Username!))
            return Conflict("Username is already taken.");

        var isUpdated = await _userAccountRepository.UpdateAsync(userAccount);

        return isUpdated ?
            NoContent() : 
            NotFound($"User with ID {id} not found.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int id)
    {
        var isDeleted = await _userAccountRepository.DeleteAsync(id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {id} not found.");
    }
    
 }
