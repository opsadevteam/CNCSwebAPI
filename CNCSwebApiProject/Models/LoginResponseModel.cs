namespace CNCSwebApiProject.Models
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }   
        public string? AccessToken { get; set; }

        public int ExpiresIn { get; set; }
        public string? UserGroup { get; set; }

        public string? FullName { get; set; }

    }
}
