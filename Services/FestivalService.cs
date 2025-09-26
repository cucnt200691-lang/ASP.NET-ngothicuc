using KhmerFestivalWebsite.Models;

namespace KhmerFestivalWebsite.Services
{
    public class FestivalService : IFestivalService
    {
        private static List<Festival> _festivals = new()
        {
            new Festival
            {
                Id = "1",
                Name = "Lễ Chol Chnam Thmay",
                Description = "Tết cổ truyền của người Khmer, đánh dấu năm mới theo lịch Khmer",
                Meaning = "Chào đón năm mới, cầu mong may mắn và thịnh vượng",
                Organization = "Cộng đồng Khmer Nam Bộ",
                TimePeriod = "Tháng 4 âm lịch",
                Location = "Các tỉnh Nam Bộ",
                ImageUrl = "https://images.baodantoc.vn/uploads/2021/Th%C3%A1ng%204/Ng%C3%A0y%2014/chol-chnam-thmay.jpg"
            },
            new Festival
            {
                Id = "2",
                Name = "Lễ Pchum Ben",
                Description = "Lễ cúng ông bà tổ tiên quan trọng nhất của người Khmer",
                Meaning = "Tưởng nhớ và báo hiếu với tổ tiên",
                Organization = "Các chùa Khmer",
                TimePeriod = "Tháng 9-10 âm lịch",
                Location = "Các chùa Khmer Nam Bộ",
                ImageUrl = "https://baodantoc.vn/file/e7837c02845ffd04018473a6df282e92/dataimages/202009/original/images2359008_1.jpg"
            },
            new Festival
            {
                Id = "3",
                Name = "Lễ Ok Om Bok",
                Description = "Lễ hội cúng trăng và cầu mưa của người Khmer",
                Meaning = "Cầu mong mưa thuận gió hòa, mùa màng bội thu",
                Organization = "Cộng đồng Khmer",
                TimePeriod = "Rằm tháng 10 âm lịch",
                Location = "Bờ sông, ao hồ",
                ImageUrl = "https://images.baodantoc.vn/uploads/2021/Th%C3%A1ng%205/Ng%C3%A0y%208/2t21.jpg"
            }
        };

        public Task<List<Festival>> GetAllFestivalsAsync()
        {
            return Task.FromResult(_festivals);
        }

        public Task<Festival?> GetFestivalByIdAsync(string id)
        {
            var festival = _festivals.FirstOrDefault(f => f.Id == id);
            return Task.FromResult(festival);
        }

        public Task<List<Festival>> SearchFestivalsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                return GetAllFestivalsAsync();

            var results = _festivals.Where(f => 
                f.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Location.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return Task.FromResult(results);
        }

        public Task<Festival> CreateFestivalAsync(Festival festival)
        {
            festival.Id = Guid.NewGuid().ToString();
            festival.CreatedAt = DateTime.UtcNow;
            festival.UpdatedAt = DateTime.UtcNow;
            _festivals.Add(festival);
            return Task.FromResult(festival);
        }

        public Task<Festival?> UpdateFestivalAsync(Festival festival)
        {
            return UpdateFestivalAsync(festival.Id, festival);
        }

        public Task<Festival?> UpdateFestivalAsync(string id, Festival festival)
        {
            var existingFestival = _festivals.FirstOrDefault(f => f.Id == id);
            if (existingFestival == null)
                return Task.FromResult<Festival?>(null);

            existingFestival.Name = festival.Name;
            existingFestival.Description = festival.Description;
            existingFestival.Meaning = festival.Meaning;
            existingFestival.Organization = festival.Organization;
            existingFestival.TimePeriod = festival.TimePeriod;
            existingFestival.Location = festival.Location;
            existingFestival.ImageUrl = festival.ImageUrl;
            existingFestival.UpdatedAt = DateTime.UtcNow;

            return Task.FromResult<Festival?>(existingFestival);
        }

        public Task<bool> DeleteFestivalAsync(string id)
        {
            var festival = _festivals.FirstOrDefault(f => f.Id == id);
            if (festival == null)
                return Task.FromResult(false);

            _festivals.Remove(festival);
            return Task.FromResult(true);
        }
    }
}