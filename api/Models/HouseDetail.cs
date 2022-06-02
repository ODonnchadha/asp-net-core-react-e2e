namespace api.Models
{
    public record HouseDetail
    (
        int Id, 
        string? Address, 
        string? Country,
        int Price,
        string? Description,
        string? Photo
    );
}