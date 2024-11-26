using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSwebApiProject.Repository
{
    public class DescriptionRepository : IDescriptionRepository
    {
        private readonly CncssystemContext _context;

        public DescriptionRepository(CncssystemContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDescriptionAsync(TblDescriptions description)
        {
            await _context.TblDescriptions.AddAsync(description);
            return await SaveAsync();
        }

        public async Task<bool> DeleteDescriptionAsync(TblDescriptions description)
        {
            var existingDescription = await _context.TblDescriptions.FindAsync(description.Id);
            if (existingDescription != null)
            {
                _context.Entry(existingDescription).State = EntityState.Detached;
            }
            _context.TblDescriptions.Remove(description);
            return await SaveAsync();
        }

        public async Task<bool> DescriptionExistsAsync(int descriptionId)
        {
            return await _context.TblDescriptions.AnyAsync(t => t.Id == descriptionId);
        }

        public async Task<TblDescriptions> GetDescriptionAsync(int id)
        {
            return await _context.TblDescriptions.FindAsync(id);
        }

        public async Task<ICollection<TblDescriptions>> GetDescriptionsAsync()
        {
            return await _context.TblDescriptions.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateDescriptionAsync(TblDescriptions description)
        {
            _context.TblDescriptions.Update(description);
            return await SaveAsync();
        }
    }
}
