using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Model
{
    [Table("UserProfile", Schema = "CW2")]
    public class UserProfile
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Location { get; set; }

        public string Birthday { get; set; }

        public string AboutMe { get; set; }

        public string ProfilePicture { get; set; }

        public string Units { get; set; }

        public string ActivityTimePreference { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string MarketingLanguage { get; set; }

        public int Admin { get; set; }
    }
}