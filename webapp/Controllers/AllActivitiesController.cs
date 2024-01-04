using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Model;

namespace webapp.Controllers
{
    [Route("/activities")]
    [ApiController]
    public class AllActivitiesController
    {
        private readonly DataContext _dataContext;

        public AllActivitiesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityData>> Get()
        {
            return await _dataContext.FavouriteActivities.ToListAsync();
        }
    }
}