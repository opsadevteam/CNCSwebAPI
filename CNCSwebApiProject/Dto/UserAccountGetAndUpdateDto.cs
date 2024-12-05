using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto;

public class UserAccountGetAndUpdateDto
{
    public int Id { get; set; }
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
