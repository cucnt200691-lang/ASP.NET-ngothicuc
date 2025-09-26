using KhmerFestivalWebsite.Models;

namespace KhmerFestivalWebsite.Services
{
    public interface IFestivalService
    {
        Task<List<Festival>> GetAllFestivalsAsync();
        Task<Festival?> GetFestivalByIdAsync(string id);
        Task<List<Festival>> SearchFestivalsAsync(string query);
        Task<Festival> CreateFestivalAsync(Festival festival);
        Task<Festival?> UpdateFestivalAsync(Festival festival);
        Task<Festival?> UpdateFestivalAsync(string id, Festival festival);
        Task<bool> DeleteFestivalAsync(string id);
    }
}