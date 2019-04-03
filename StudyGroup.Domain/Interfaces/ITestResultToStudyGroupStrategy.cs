using System.Threading.Tasks;

namespace StudyGroup.Domain.Interfaces
{
    public interface ITestResultToStudyGroupStrategy<T> 
    {
        Task<T> GenerateStudyGroupsAsync(string[,] testGrid);
    }
}
