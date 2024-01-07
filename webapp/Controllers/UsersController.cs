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

        [HttpPut]
        [Route("/api/user/new")]
        public async Task<string> CreateNewUser([FromBody] NewUser bodyUser)
        {
            int rowsAffected;
            string sql = "EXEC CW2.CreateNewProfile @Username, @Email, @Password, @Units, @ActivityTimePreference, @MarketingLanguage, @Admin";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameters    
                new SqlParameter { ParameterName = "@Username", Value = bodyUser.Username },
                new SqlParameter { ParameterName = "@Password", Value = bodyUser.Password},
                new SqlParameter { ParameterName = "@Email", Value = bodyUser.Email},
                new SqlParameter { ParameterName = "@Units", Value = "Metric"},
                new SqlParameter { ParameterName = "@ActivityTimePreference", Value = "Speed"},
                new SqlParameter { ParameterName = "@MarketingLanguage", Value = "English (UK)"},
                new SqlParameter { ParameterName = "@Admin", Value = 0}
            };

            using (DataContext db = new DataContext())
            {
                rowsAffected = db.Database.ExecuteSqlRaw(sql, parms.ToArray());
                return await new ResultOutput<string>("User successfully created.").Serialize();
            }
        }

        [HttpPost]
        [Route("/api/user/get-token")]
        public async Task<string> GenerateToken([FromBody] Login userCredentials)
        {
            using (DataContext dbContext = new DataContext())
            {
                // Check the database for credentials
                UserProfile userProfile = dbContext.UserProfiles.FirstOrDefault(user => user.Email == userCredentials.Email);

                if (userProfile == null)
                {
                    return await new ResultOutput<string>("User not found in the database").Serialize();
                }
                string authToken = Token.Instance.AuthorizeUser(userProfile.UserID);
                return await new ResultOutput<string>(authToken).Serialize();
            }
        }

        [HttpPost]
        [Route("/api/user/get-self/")]
        public async Task<string> GetUserProfile([FromBody] SecurityKey securityKey)
        {
            Token tokenManager = Token.Instance;
            int userID = tokenManager.GetIDFromToken(securityKey.Key);

            DataContext dbContext = new DataContext();
            UserProfile userProfile = dbContext.UserProfiles.FirstOrDefault(user => user.UserID == userID);

            if (userProfile == null)
            {
                return await new ResultOutput<string>("User profile not found").Serialize();
            }
            return await new ResultOutput<ShowSelf>(new ShowSelf(userProfile)).Serialize();
        }
    }
}