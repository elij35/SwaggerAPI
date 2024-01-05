using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp.Controllers
{
    [Route("/activities")]
    [ApiController]
    public class AllActivitiesController
    {
        [HttpGet]
        public async Task<IEnumerable<ActivityData>> Get()
        {
            return await new DataContext().FavouriteActivities.ToListAsync();
        }
    }
}