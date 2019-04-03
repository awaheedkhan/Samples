using StudyGroup.Domain.Entities;

namespace StudyGroup.Web.EntityMappers
{
    public class TestResultMapper
    {
        public TestResult Map() {
            return new TestResult {
                ResultMatrix = new string[,] {
                    { "","","Simon","","" },
                    { "","Sergey","","Thomas","" },
                    { "","","","","" },
                    { "","Chris","","","" },
                    { "","Harry","","Roger","" },
                    { "","","","","" }
                }
            };
        }
    }
}