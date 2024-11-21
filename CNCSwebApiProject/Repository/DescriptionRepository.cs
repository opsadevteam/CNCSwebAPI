using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Repository
{
    public class DescriptionRepository : IDescription
    {
        private readonly CncssystemContext _context;

        public DescriptionRepository(CncssystemContext context)
        {
            _context = context;
        }

        public bool CreateDescription(TblDescriptions description)
        {
            _context.Add(description);

            return Save();
        }

        public bool DeleteDescription(TblDescriptions description)
        {
            _context.Remove(description);

            return Save();
        }

        public bool DescriptionExists(int descriptionId)
        {
            return _context.TblDescriptions.Any(p => p.Id == descriptionId);
        }

        public TblDescriptions GetDescription(int id)
        {
            return _context.TblDescriptions.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<TblDescriptions> GetDescriptions()
        {
            return _context.TblDescriptions.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDescription(TblDescriptions description)
        {
            _context.Update(description);
            return Save();
        }
    }
}
