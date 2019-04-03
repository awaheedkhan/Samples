using StudyGroup.Domain.Interfaces;
using StudyGroup.Infrastructure.Strategies;
using StudyGroup.Services;
using System.Collections.Generic;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace StudyGroup.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "StudyGroupsApi",
                routeTemplate: "api/v{version}/StudyGroups/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();

            container.RegisterType<IStudyGroupService<IEnumerable<Domain.Entities.StudyGroup>>, StudyGroupService>(new InjectionConstructor(typeof(ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>>)));
            container.RegisterType<ITestResultToStudyGroupStrategy<IEnumerable<Domain.Entities.StudyGroup>>, AdjacentStudentsStrategy<IEnumerable<Domain.Entities.StudyGroup>>>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
