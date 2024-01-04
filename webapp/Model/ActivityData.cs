using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Model
{
    [Table("FavouriteActivities", Schema = "CW2")]
    public class ActivityData
    {
        [Key]
        public int FavouriteActivityID { get; set; }

        public string FavouriteActivity { get; set; }
    }
}