using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp.Controllers
{
    [ApiController]
    public class UsersController
    {
        [HttpGet]
        [Route("/api/user/public/{id}")]
        public async Task<string> GetPublicUserProfile([FromRoute] int id)
        {
            using (DataContext dbContext = new DataContext())
            {
                UserProfile userProfile = dbContext.UserProfiles.FirstOrDefault(user => user.UserID == id);

                if (userProfile == null)
                {
                    return await new ResultOutput<string>("User profile not found").Serialize();
                }
                PublicUser publicUserInfo = new PublicUser(userProfile.UserName, userProfile.AboutMe, userProfile.ProfilePicture);
                return await new ResultOutput<PublicUser>(publicUserInfo).Serialize();
            }
        }
    }
}