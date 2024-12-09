using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.UserAccountsDtos;

public class UserAccountChangePasswordDto
{
[Required]
public required string NewPassword { get; set; }

}
