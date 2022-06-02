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
                    h.Id, h.Address, h.Coutry, h.Price)
            ).ToListAsync();
        }
        public async Task<Models.HouseDetail?> GetDetail(int id)
        {
            var d = await context.Houses.SingleOrDefaultAsync(
                detail => detail.Id == id);

                if (d == null)
                {
                    return null;
                }
            return new Models.HouseDetail(
                d.Id, d.Address, d.Coutry, d.Price, d.Description, d.Photo);
        }
    }
}