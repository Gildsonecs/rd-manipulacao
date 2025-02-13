using Microsoft.EntityFrameworkCore;
using RdManipulation.Domain.Entities;
using RdManipulation.Domain.Interfaces;
using RdManipulation.Infra.Data.Contexts;

namespace RdManipulation.Infra.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task AddAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) return false;

            video.IsDeleted = true;  // Soft delete
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
