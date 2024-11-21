using CNCSwebApiProject.Models;

namespace CNCSwebApiProject.Interface
{
    public interface IDescription
    {
        ICollection<TblDescriptions> GetDescriptions();
        TblDescriptions GetDescription(int id);
        bool DescriptionExists(int descriptionId);
        bool CreateDescription(TblDescriptions description);
        bool UpdateDescription(TblDescriptions description);
        bool DeleteDescription(TblDescriptions description);
        bool Save();
    }
}
