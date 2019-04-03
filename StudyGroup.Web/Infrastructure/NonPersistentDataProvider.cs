using StudyGroup.Domain.Interfaces;
using System;

namespace StudyGroup.Web.Infrastructure
{
    public class NonPersistentDataProvider<T> : IDataProvider<T>
    {
        public T Populate()
        {
            var entityName = typeof(T).Name;

            var entityMapperType = this.GetType().Assembly.GetType($"StudyGroup.Web.EntityMappers.{entityName}Mapper");
            var constructorInfo = entityMapperType.GetConstructor(new Type[] { });
            var methodInfo = entityMapperType.GetMethod("Map");

            var entityMapper = constructorInfo.Invoke(new object[] { });
            var t = methodInfo.Invoke(entityMapper, new object[] { });


            return (T)t;
        }
    }
}