using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudyGroup.Domain.Interfaces;
using StudyGroup.Services.Test.Builders;
using System.Collections.Generic;

namespace StudyGroup.Services.Tests
{
    [TestClass()]
    public class StudyGroupServiceTests
    {
        private Mock<ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>>> _mockStrategy;
        private IStudyGroupService<IEnumerable<Domain.Entities.StudyGroup>> _studyGroupService;

        private string[,] _testResult;
        private IEnumerable<Domain.Entities.StudyGroup> _studyGroups;

        [TestInitialize]
        public void Initialize()
        {
            _mockStrategy = new Mock<ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>>>();
            _studyGroupService = new StudyGroupService(_mockStrategy.Object);
            _testResult = new TestResultBuilder().BuildTestResults();
            _studyGroups = new StudyGroupsBuilder().BuildStudyGroups();
        }

        [TestMethod()]
        public void GenerateStudyGroupsTest()
        {
            //Arrange
            _mockStrategy.Setup(x => x.GenerateStudyGroupsAsync(_testResult)).ReturnsAsync(_studyGroups);

            //Act
            var result = _studyGroupService.GenerateStudyGroupsAsync(_testResult).GetAwaiter().GetResult();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, _studyGroups);
        }
    }
}