using System.Collections.Generic;

namespace StudyGroup.Services.Test.Builders
{
    public class StudyGroupsBuilder
    {
        public IEnumerable<Domain.Entities.StudyGroup> BuildStudyGroups() {
            return new List<Domain.Entities.StudyGroup> {
                new Domain.Entities.StudyGroup{ GroupMembers = new List<string>(new string[]{"Simon","Sergey","Thomas"}) } ,
                new Domain.Entities.StudyGroup{ GroupMembers = new List<string>(new string[]{"Chris","Harry"}) },
                new Domain.Entities.StudyGroup{ GroupMembers = new List<string>(new string[]{"Roger"}) }
            };
        }
    }
}
