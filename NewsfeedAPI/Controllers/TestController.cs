using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NewsfeedAPI.Controllers
{
    public class TestController(NewsfeedDbContext context) : Controller
    {
        [HttpGet("data")]
        public async Task<object> GetDataFromNewsfeed()
        {
            return await context.Newsfeeds.ToListAsync();
        }
    }
}
