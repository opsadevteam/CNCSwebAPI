using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto;

public class UserAccountChangePasswordDto
{
public int Id { get; set; } 
[Required]
public required string NewPassword { get; set; }

}
