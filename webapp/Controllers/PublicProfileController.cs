using Microsoft.AspNetCore.Mvc;
using webapp.Model;

namespace webapp.Controllers
{
    [Route("/user/public/{id}")]
    [ApiController]

    public class PublicProfileController
    {
        public struct PublicUser(string username, string? aboutMe, string? profilePic)
        {
            public string Username { get; set; } = username;
            public string? AboutMe { get; set; } = aboutMe;
            public string? ProfilePictureLink { get; set; } = profilePic;
        }

        [HttpGet]
        public async Task<string> Get([FromRoute] int id)
        {
            DataContext db = new();
            UserProfile? dbUser = db.UserProfiles.FirstOrDefault(user => user.UserID == id);
            return await new ResultOutput<PublicUser>(new PublicUser(dbUser.UserName, dbUser.AboutMe, dbUser.ProfilePicture)).Serialize();
        }
    }
}