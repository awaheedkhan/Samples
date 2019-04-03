using Newtonsoft.Json;
using StudyGroup.Domain.Entities;
using StudyGroup.Domain.Interfaces;
using StudyGroup.Web.Infrastructure;
using StudyGroup.Web.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace StudyGroup.Web.Controllers
{
    public class StudyGroupsController : Controller
    {
        private readonly IReadOnlyRepository<TestResult> _readOnlyRepository;

        public StudyGroupsController(IReadOnlyRepository<TestResult> readonlyRepository)
        {
            _readOnlyRepository = readonlyRepository;
        }

        // GET: StudyGroups
        [HttpGet]
        public ActionResult Index()
        {
            var model = new StudyGroupsIndex() {
                TestResults = _readOnlyRepository.Get().ResultMatrix
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StudyGroupsIndex model)
        {
            model.TestResults = _readOnlyRepository.Get().ResultMatrix;

            var apiUrl = Url.RouteUrl("StudyGroupsApi", new {
                    httproute = ""
                    , version = 1
                    , controller = "StudyGroups"}
                , Request.Url.Scheme);

            var serviceManager = new StudyGroupHttpServiceManager(apiUrl, model.TestResults);

            try
            {
                model.StudyGroups = serviceManager.PostAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                //Handle exception
                throw;
            }
            

            return View(model);
        }
    }
}
