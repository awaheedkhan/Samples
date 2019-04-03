using System.Collections.Generic;

namespace StudyGroup.Domain.Interfaces
{
    public interface IReadOnlyRepository<T>
    {
        T Get();
    }
}
