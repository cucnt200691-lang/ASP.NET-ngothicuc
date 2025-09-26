using KhmerFestivalWebsite.Models;

namespace KhmerFestivalWebsite.Services
{
    public class NewsService : INewsService
    {
        private static List<News> _news = new()
        {
            new News
            {
                Id = "1",
                Title = "Lễ hội Chol Chnam Thmay 2024 sẽ được tổ chức tại TP.HCM",
                Content = "Ủy ban nhân dân TP.HCM thông báo sẽ tổ chức Lễ hội Chol Chnam Thmay 2024 với quy mô lớn tại Công viên Tao Đàn. Lễ hội sẽ diễn ra từ ngày 13-15 tháng 4 âm lịch với nhiều hoạt động văn hóa đặc sắc như múa truyền thống, triển lãm ảnh, gian hàng ẩm thực và các trò chơi dân gian. Đây là dịp để cộng đồng người Khmer và bạn bè quốc tế hiểu thêm về nét đẹp văn hóa truyền thống của dân tộc Khmer.",
                Excerpt = "Lễ hội Tết cổ truyền Khmer sẽ diễn ra với nhiều hoạt động văn hóa đặc sắc",
                ImageUrl = "https://images.baodantoc.vn/uploads/2021/Th%C3%A1ng%204/Ng%C3%A0y%2014/chol-chnam-thmay.jpg",
                PublishedAt = DateTime.UtcNow.AddDays(-5)
            },
            new News
            {
                Id = "2",
                Title = "Bảo tồn và phát huy giá trị văn hóa lễ hội Khmer",
                Content = "Các chuyên gia văn hóa nhấn mạnh tầm quan trọng của việc bảo tồn và phát huy các giá trị văn hóa truyền thống của dân tộc Khmer. Trong bối cảnh toàn cầu hóa, việc giữ gìn bản sắc văn hóa dân tộc trở nên cấp thiết hơn bao giờ hết. Các lễ hội truyền thống không chỉ là dịp để cộng đồng sum họp mà còn là cơ hội truyền đạt những giá trị tinh thần quý báu cho thế hệ trẻ. Cần có sự phối hợp giữa các cấp chính quyền, tổ chức xã hội và cộng đồng để xây dựng các chương trình bảo tồn hiệu quả.",
                Excerpt = "Cần có những biện pháp cụ thể để bảo tồn văn hóa truyền thống",
                ImageUrl = "https://baodantoc.vn/file/e7837c02845ffd04018473a6df282e92/dataimages/202009/original/images2359008_1.jpg",
                PublishedAt = DateTime.UtcNow.AddDays(-10)
            },
            new News
            {
                Id = "3",
                Title = "Lễ Ok Om Bok - Nét đẹp văn hóa tâm linh của người Khmer",
                Content = "Lễ Ok Om Bok không chỉ là một lễ hội mà còn thể hiện tín ngưỡng sâu sắc của người Khmer với thiên nhiên và vũ trụ. Được tổ chức vào đêm rằm tháng 10 âm lịch, lễ hội này thể hiện lòng biết ơn của người Khmer đối với mặt trăng - nguồn sáng ban đêm và là biểu tượng của sự thuần khiết. Trong đêm lễ, người dân sẽ thả đèn hoa đăng trên sông, cúng bánh cốm dẹp và tổ chức các hoạt động văn nghệ truyền thống. Đây cũng là dịp để các gia đình sum họp và cầu nguyện cho một mùa màng bội thu.",
                Excerpt = "Khám phá ý nghĩa sâu sắc của lễ hội cúng trăng",
                ImageUrl = "https://images.baodantoc.vn/uploads/2021/Th%C3%A1ng%205/Ng%C3%A0y%208/2t21.jpg",
                PublishedAt = DateTime.UtcNow.AddDays(-15)
            }
        };

        public Task<List<News>> GetAllNewsAsync()
        {
            return Task.FromResult(_news.OrderByDescending(n => n.PublishedAt).ToList());
        }

        public Task<News?> GetNewsByIdAsync(string id)
        {
            var news = _news.FirstOrDefault(n => n.Id == id);
            return Task.FromResult(news);
        }

        public Task<List<News>> GetLatestNewsAsync(int count = 3)
        {
            var latestNews = _news.OrderByDescending(n => n.PublishedAt).Take(count).ToList();
            return Task.FromResult(latestNews);
        }

        public Task<News> CreateNewsAsync(News news)
        {
            news.Id = Guid.NewGuid().ToString();
            news.CreatedAt = DateTime.UtcNow;
            news.UpdatedAt = DateTime.UtcNow;
            if (news.PublishedAt == default)
                news.PublishedAt = DateTime.UtcNow;
            _news.Add(news);
            return Task.FromResult(news);
        }

        public Task<News?> UpdateNewsAsync(News news)
        {
            return UpdateNewsAsync(news.Id, news);
        }

        public Task<News?> UpdateNewsAsync(string id, News news)
        {
            var existingNews = _news.FirstOrDefault(n => n.Id == id);
            if (existingNews == null)
                return Task.FromResult<News?>(null);

            existingNews.Title = news.Title;
            existingNews.Content = news.Content;
            existingNews.Excerpt = news.Excerpt;
            existingNews.ImageUrl = news.ImageUrl;
            existingNews.PublishedAt = news.PublishedAt;
            existingNews.UpdatedAt = DateTime.UtcNow;

            return Task.FromResult<News?>(existingNews);
        }

        public Task<bool> DeleteNewsAsync(string id)
        {
            var news = _news.FirstOrDefault(n => n.Id == id);
            if (news == null)
                return Task.FromResult(false);

            _news.Remove(news);
            return Task.FromResult(true);
        }
    }
}