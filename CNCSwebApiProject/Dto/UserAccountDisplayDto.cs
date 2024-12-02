using System.ComponentModel.DataAnnotations;

namespace CNCSwebApiProject.Dto;

public class UserAccountDisplayDto
    {
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required  string UserGroup { get; set; }
    public  required string Status { get; set; }
    public DateTime? DateAdded { get; set; }
    }
