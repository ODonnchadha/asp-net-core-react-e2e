namespace api.Interfaces.Repositories
{
    public interface IHouseRepository
    {
        Task<Models.HouseDetail> Add(Models.HouseDetail dto);
        Task<List<Models.House>> Get();
        Task<Models.HouseDetail?> GetDetail(int id);
        Task Delete(int id);
        Task<Models.HouseDetail> Update(Models.HouseDetail dto);
    }
}