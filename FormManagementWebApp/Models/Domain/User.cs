namespace FormManagementWebApp.Models.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsLoggedIn { get; set; }
    
    public ICollection<Form> Forms { get; set; }
}