using api.Contexts;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly HouseDbContext context;
        public HouseRepository(HouseDbContext context) => this.context = context;
        public async Task<HouseDetail> Add(HouseDetail dto)
        {
            var entity = new Entities.House {};
            ModelToEntity(dto, entity);
            context.Add(entity);
            await context.SaveChangesAsync();

            return EntityToModel(entity);
        }
        public async Task Delete(int id)
        {
            var entity = await context.Houses.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Error deleting HouseDetail {id}.");
            }
            context.Houses.Remove(entity);
            await context.SaveChangesAsync();
        }
        private static HouseDetail EntityToModel(Entities.House entity)
        {
                return new Models.HouseDetail(
                    entity.Id, entity.Address, entity.Coutry, entity.Price, entity.Description, entity.Photo);
        }
        private static void ModelToEntity(HouseDetail model, Entities.House entity)
        {
            entity.Address = model.Address;
            entity.Coutry = model.Country;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Photo = model.Photo;
        }
        public async Task<List<Models.House>> Get()
            {
                return await context.Houses.Select(
                    h => new Models.House(
                        h.Id, h.Address, h.Coutry, h.Price)
                ).ToListAsync();
            }
        public async Task<Models.HouseDetail?> GetDetail(int id)
        {
            var entity= await context.Houses.SingleOrDefaultAsync(
                detail => detail.Id == id);

                if (entity == null)
                {
                    return null;
                }
            return EntityToModel(entity);
        }
        public async Task<HouseDetail> Update(HouseDetail dto)
        {
            var entity = await context.Houses.FindAsync(dto.Id);
            if (entity == null)
            {
                throw new ArgumentException($"Error updating HouseDetail {dto.Id}.");
            }
            ModelToEntity(dto, entity);
            // NOTE: No such thing as an update command. Force EF to recognize context changes.
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return EntityToModel(entity);
        }
    }
}