using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Model
{
    [Table("UserProfile", Schema = "CW2")]
    public class UserProfile
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Location { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Birthday { get; set; }

        public string? AboutMe { get; set; }

        public string? ProfilePicture { get; set; }

        [Required]
        public string Units { get; set; }

        [Required]
        public string ActivityTimePreference { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        [Required]
        public string MarketingLanguage { get; set; }

        public int Admin { get; set; }
    }
}