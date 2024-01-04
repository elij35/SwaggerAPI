using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Model
{
    [Table("UserProfileFavouriteActivities", Schema = "CW2")]
    [PrimaryKey(nameof(UserID), nameof(FavouriteActivityID))]
    public class UserActivity
    {
        public int UserID { get; set; }

        public int FavouriteActivityID { get; set; }
    }
}