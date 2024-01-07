using Microsoft.AspNetCore.Mvc;
using webapp.Model;

namespace webapp.Controllers
{
    [ApiController]
    public class AdminController
    {

        [HttpDelete]
        [Route("/api/admin/delete/{id}")]

        public async Task<string> DeleteUser([FromRoute] int id, [FromBody] AuthenticationAPI.Login adminCredentials)
        {
            using (DataContext dbContext = new DataContext())
            {
                // Check Authentication API to verify admin permission
                bool isAdmin = await AuthenticationAPI.AuthenticateUser(adminCredentials.Email, adminCredentials.Password);

                if (!isAdmin)
                {
                    return await new ResultOutput<string>("Unauthorized: Not an admin").Serialize();
                }

                // Check database for the user to be deleted
                UserProfile userToDelete = dbContext.UserProfiles.FirstOrDefault(user => user.UserID == id);

                if (userToDelete == null)
                {
                    return await new ResultOutput<string>("User not found in the database").Serialize();
                }

                dbContext.UserProfiles.Remove(userToDelete);
                await dbContext.SaveChangesAsync();

                return await new ResultOutput<string>("User deleted successfully").Serialize();
            }
        }
    }
}