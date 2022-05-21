namespace api.Models
{
    public record House
    (
        int Id, 
        string? Address, 
        string? Country,
        int Price
    );
}