using System.Threading.Tasks;

namespace StudyGroup.Domain.Interfaces
{
    public interface IStudyGroupService<T>
    {
        Task<T> GenerateStudyGroupsAsync(string[,] testGrid);
    }
}
