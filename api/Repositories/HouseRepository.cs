using api.Contexts;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly HouseDbContext context;
        public HouseRepository(HouseDbContext context) => this.context = context;

        public async Task<List<Models.House>> Get()
        {
            return await context.Houses.Select(
                h => new Models.House(
                    h.Id, h.Description, h.Coutry, h.Price)
            ).ToListAsync();
        }
    }
}