using StudyGroup.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroup.Services
{
    public class StudyGroupService : IStudyGroupService<IEnumerable<Domain.Entities.StudyGroup>>
    {
        private readonly ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>> _testResultToStudyGroupStrategy;

        public StudyGroupService(ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>> testResultToStudyGroupStrategy)
        {
            _testResultToStudyGroupStrategy = testResultToStudyGroupStrategy;        
        }

        protected virtual async Task<IEnumerable<Domain.Entities.StudyGroup>> ExecuteStrategyAsync(string[,] testResult)
        {
            return await _testResultToStudyGroupStrategy.GenerateStudyGroupsAsync(testResult);
        }

        public virtual async Task<IEnumerable<Domain.Entities.StudyGroup>> GenerateStudyGroupsAsync(string[,] testResults)
        {
            return await ExecuteStrategyAsync(testResults);
        }
    }
}
