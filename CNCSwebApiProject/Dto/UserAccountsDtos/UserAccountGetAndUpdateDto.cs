using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto.UserAccountsDtos;

public class UserAccountGetAndUpdateDto
{
    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required  string UserGroup { get; set; }
    [Required]
    public  required string Status { get; set; }
}
