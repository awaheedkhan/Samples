namespace StudyGroup.Services.Test.Builders
{
    public class TestResultBuilder
    {
        public string[,] BuildTestResults() {
            return new string[,] {
                { "", "", "Simon", "", "" },
                { "", "Sergey", "", "Thomas", "" },
                { "", "", "", "", "" },
                { "", "Chris", "", "", "" },
                { "", "Harry", "", "Roger", "" },
                { "", "", "", "", "" }
            };
        }
    }
}
