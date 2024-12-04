namespace CNCSwebApiProject.Dto;

public class UserAccountCreateDto
{
    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserGroup { get; set; }

    public string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LogId { get; set; }
}