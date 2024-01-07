using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp.Controllers
{
    [ApiController]
    public class ActivitiesController
    {
        [HttpGet]
        [Route("/api/activities")]
        public async Task<IEnumerable<ActivityData>> Get()
        {
            return await new DataContext().FavouriteActivities.ToListAsync();
        }

    }
}