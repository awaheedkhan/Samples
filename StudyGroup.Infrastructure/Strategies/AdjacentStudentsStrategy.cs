using StudyGroup.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroup.Infrastructure.Strategies
{
    public class AdjacentStudentsStrategy<T> : ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>>
    {
        public virtual async Task<IEnumerable<Domain.Entities.StudyGroup>> GenerateStudyGroupsAsync(string[,] testResultMatrix)
        {
            return Task.Run(() => CreateStudyGroup(testResultMatrix)).GetAwaiter().GetResult();
        }

        private IEnumerable<Domain.Entities.StudyGroup> CreateStudyGroup(string[,] testResultMatrix) {
            var studyGroups = new List<Domain.Entities.StudyGroup>();
            var markedCells = new List<string>();
            
            for (int t = 0; t < testResultMatrix.GetLength(0); t++)
            {
                for (int m = 0; m < testResultMatrix.GetLength(1); m++)
                {
                    var studyGroup = CreateStudyGroup(t, m, testResultMatrix, ref markedCells);

                    if (studyGroup != null)
                        studyGroups.Add(new Domain.Entities.StudyGroup {
                            GroupMembers = studyGroup
                        });
                }
            }

            return studyGroups;
        }

        private List<string> CreateStudyGroup(int timeIndex, int marksIndex, string[,] testResultMatrix, ref List<string> markedCells)
        {
            if(string.IsNullOrEmpty(testResultMatrix[timeIndex, marksIndex]) || markedCells.Contains($"{timeIndex}-{marksIndex}"))
                return null;

            var studyGroup = new List<string> { testResultMatrix[timeIndex, marksIndex] };
            markedCells.Add($"{timeIndex}-{marksIndex}");

            var h = marksIndex + 1;

            if (!(string.IsNullOrEmpty(testResultMatrix[timeIndex, h]) || markedCells.Contains($"{timeIndex}-{h}")))
            {
                studyGroup.Add(testResultMatrix[timeIndex, h]);
                markedCells.Add($"{timeIndex}-{h}");
            }

            var v = timeIndex + 1;

            if (!(string.IsNullOrEmpty(testResultMatrix[v, marksIndex]) || markedCells.Contains($"{v}-{marksIndex}")))
            {
                studyGroup.Add(testResultMatrix[v, marksIndex]);
                markedCells.Add($"{v}-{marksIndex}");
            }

            if (marksIndex > 0)
            {
                var dl = marksIndex - 1;

                if (!(string.IsNullOrEmpty(testResultMatrix[v,dl]) || markedCells.Contains($"{v}-{dl}")))
                {
                    studyGroup.Add(testResultMatrix[v, dl]);
                    markedCells.Add($"{v}-{dl}");
                }
            }

            if (marksIndex < testResultMatrix.GetLength(1) - 1)
            {
                var dr = marksIndex + 1;

                if (!(string.IsNullOrEmpty(testResultMatrix[v, dr]) || markedCells.Contains($"{v}-{dr}")))
                {
                    studyGroup.Add(testResultMatrix[v, dr]);
                    markedCells.Add($"{v}-{dr}");
                }
            }
            

            return studyGroup;
        }
    }
}
