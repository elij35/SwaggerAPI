using System.ComponentModel.DataAnnotations;
using webapp.Model;

public struct NewUser
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public struct PublicUser(string username, string? aboutMe, string? profilePictureLink)
{
    public string Username { get; set; } = username;
    public string? AboutMe { get; set; } = aboutMe;
    public string? ProfilePictureLink { get; set; } = profilePictureLink;
}

public struct ShowSelf(UserProfile user)
{
    public string Username { get; set; } = user.UserName;
    public string Email { get; set; } = user.Email;
    public string? AboutMe { get; set; } = user.AboutMe;
    public string? Location { get; set; } = user.Location;
    public string Units { get; set; } = user.Units;
    public string ActivityTimePreference { get; set; } = user.ActivityTimePreference;
    public int? Height { get; set; } = user.Height;
    public int? Weight { get; set; } = user.Weight;
    public string? Birthday { get; set; } = user.Birthday;
    public string? ProfilePictureLink { get; set; } = user.ProfilePicture;
    public string Language { get; set; } = user.MarketingLanguage;
}

public struct UpdateUser
{
    public string Key { get; set; }
    public string Email { get; set; }
    public string? Location { get; set; }
    public string? Birthday { get; set; }
    public string? AboutMe { get; set; }
    public string? ProfilePicture { get; set; }
    public string Units { get; set; }
    public string ActivityTimePreference { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public string MarketingLanguage { get; set; }
}

public struct SecurityKey
{
    public string Key { get; set; }
}

public struct TokenInfo
{
    public int UserID { get; set; }
}