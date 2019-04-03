using StudyGroup.Domain.Entities;
using StudyGroup.Domain.Interfaces;
using System;

namespace StudyGroup.Web.Infrastructure
{
    public class ReadOnlyNonPersitentDataRepository<T> : IReadOnlyRepository<T>
    {
        private readonly IDataProvider<T> _dataProvider;

        public ReadOnlyNonPersitentDataRepository(IDataProvider<T> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public T Get()
        {
            return _dataProvider.Populate();
        }
    }
}