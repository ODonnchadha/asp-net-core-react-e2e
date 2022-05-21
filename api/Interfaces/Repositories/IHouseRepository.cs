namespace api.Interfaces.Repositories
{
    public interface IHouseRepository
    {
        Task<List<Models.House>> Get();
    }
}