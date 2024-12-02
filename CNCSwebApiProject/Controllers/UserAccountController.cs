using Microsoft.AspNetCore.Cors;
using AutoMapper;
using CNCSproject.Interface;
using CNCSwebApiProject.Dto;
using CNCSwebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using CNCSwebApiProject.Services.UserAccountService;

namespace CNCSwebApiProject.Controllers;

[EnableCors("AllowOrigin")]
[Route("api/v1/[controller]")]
[ApiController]
public class UserAccountController(IUserAccountService _UserAccountService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAccountDisplayDto>>> GetUserAccountsAsync()
    {
        var userDtoList = mapper.Map<List<UserAccountDisplayDto>>(await _UserAccountService.GetAllAsync());

        return userDtoList.Any() ?
            Ok(userDtoList) :
            NotFound("No user accounts found.");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserAccountDisplayDto>> GetUserAccountAsync(int id)
    {
        var userDto = mapper.Map<UserAccountDisplayDto>(await _UserAccountService.GetAsync(id));

        return userDto is not null ?
            Ok(userDto) :
            NotFound($"User with ID {id} not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAccountAsync(UserAccountUpsertDto newUser)
    {
        if (newUser is null) 
            return BadRequest("Invalid user account data.");

            if (await _UserAccountService.IsUserExistsAsync(newUser.Username!))
                return Conflict("Username is already taken.");

        var isAdded = await _UserAccountService.AddAsync(newUser);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding user account.");
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAccountAsync(int id, UserAccountUpsertDto userAccount)
    {
        if (id != userAccount.Id)
            return BadRequest("User ID mismatch.");

        if (await _UserAccountService.IsUserExistsAsync(userAccount.Username!))
            return Conflict("Username is already taken.");

        var isUpdated = await _UserAccountService.UpdateAsync(userAccount);

        return isUpdated ?
            NoContent() : 
            NotFound($"User with ID {id} not found.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int id)
    {
        var isDeleted = await _UserAccountService.DeleteAsync(id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {id} not found.");
    }
    
 }
