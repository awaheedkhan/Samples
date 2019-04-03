using Newtonsoft.Json;
using StudyGroup.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyGroup.Web.Controllers.Api.V1
{
    public class StudyGroupsController : ApiController
    {
        private readonly IStudyGroupService<IEnumerable<Domain.Entities.StudyGroup>> _studyGroupService;

        public StudyGroupsController(IStudyGroupService<IEnumerable<Domain.Entities.StudyGroup>> studyGroupService)
        {
            _studyGroupService = studyGroupService;
        }

        /// <summary>
        /// Generates study groups with chosen strategy.
        /// </summary>
        /// <param name="testResult"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetStudyGroups([FromBody]string testResult)
        {
            // Authorize request

            try
            {
                var testGrid = JsonConvert.DeserializeObject<string[,]>(testResult);

                var studyGroups = _studyGroupService.GenerateStudyGroupsAsync(testGrid).GetAwaiter().GetResult();
                return Ok(studyGroups.Select(x => x.GroupMembers.ToArray()).ToArray());
            }
            catch (System.Exception ex)
            {
                // Handle exception
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
                
            }
        }
    }
}
