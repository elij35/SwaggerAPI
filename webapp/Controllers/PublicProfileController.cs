using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp.Controllers
{
    [Route("user/public/{id}")]
    [ApiController]

    public class PublicProfileController
    {
        private readonly DataContext _dataContext;
        public PublicProfileController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<UserProfile>> Get()
        {
            return await _dataContext.UserProfiles.ToListAsync();

        }
    }
}