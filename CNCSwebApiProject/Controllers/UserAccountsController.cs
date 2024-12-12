using Microsoft.AspNetCore.Cors;
using AutoMapper;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto.UserAccountsDtos;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using CNCSwebApiProject.Services.UserAccountService;

namespace CNCSwebApiProject.Controllers;

[EnableCors("AllowOrigin")]
[Route("api/v1/[controller]")]
[ApiController]
public class UserAccountsController(IUserAccountService _UserAccountService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAccountListDto>>> GetUserAccountsAsync()
    {
        var obj = await _UserAccountService.GetAllAsync();

        return obj.Any() ?
            Ok(obj) :
            NotFound("No user accounts found.");
    }

    [HttpGet("{UserAccount_Id}")]
    public async Task<ActionResult<UserAccountGetAndUpdateDto>> GetUserAccountAsync(int UserAccount_Id)
    {
        var obj = await _UserAccountService.GetAsync(UserAccount_Id);

        return obj is not null ?
            Ok(obj) :
            NotFound($"User with ID {UserAccount_Id} not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAccountAsync(UserAccountCreateDto newUser)
    {
        if (newUser is null)
            return BadRequest("Invalid user account data.");

        if (await _UserAccountService.IsUserExistsAsync(newUser.Username!, 0))
            return Conflict("Username is already taken.");

        var isAdded = await _UserAccountService.AddAsync(newUser);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding user account.");
    }


    [HttpPut("{UserAccount_Id}")]
    public async Task<IActionResult> UpdateUserAccountDetailsAsync(int UserAccount_Id, UserAccountGetAndUpdateDto userAccount)
    {
        if (await _UserAccountService.IsUserExistsAsync(userAccount.Username!, UserAccount_Id!))
            return Conflict("Username is already taken.");

        var isUpdated = await _UserAccountService.UpdateDetailsAsync(UserAccount_Id, userAccount);

        return isUpdated ?
            NoContent() :
            NotFound($"User with ID {UserAccount_Id} not found.");
    }

    [HttpPut("{UserAccount_Id}/ChangePassword")]
    public async Task<IActionResult> UpdateUserAccountPasswordAsync(int UserAccount_Id, UserAccountChangePasswordDto userAccount)
    {
        var isUpdated = await _UserAccountService.UpdatePasswordAsync(UserAccount_Id, userAccount);

        return isUpdated ?
            NoContent() :
            NotFound($"User with ID {UserAccount_Id} not found.");
    }

    [HttpDelete("{UserAccount_Id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int UserAccount_Id)
    {
        var isDeleted = await _UserAccountService.DeleteAsync(UserAccount_Id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {UserAccount_Id} not found.");
    }

}
