using KhmerFestivalWebsite.Models;

namespace KhmerFestivalWebsite.Services
{
    public interface INewsService
    {
        Task<List<News>> GetAllNewsAsync();
        Task<News?> GetNewsByIdAsync(string id);
        Task<List<News>> GetLatestNewsAsync(int count = 3);
        Task<News> CreateNewsAsync(News news);
        Task<News?> UpdateNewsAsync(News news);
        Task<News?> UpdateNewsAsync(string id, News news);
        Task<bool> DeleteNewsAsync(string id);
    }
}