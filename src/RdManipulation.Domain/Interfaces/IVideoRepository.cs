using RdManipulation.Domain.Entities;

namespace RdManipulation.Domain.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllAsync();
        Task<Video> GetByIdAsync(int id);
        Task AddAsync(Video video);
        Task<bool> UpdateAsync(Video video);
        Task<bool> DeleteAsync(int id);
    }
}
