namespace StudyGroup.Domain.Interfaces
{
    public interface IDataProvider<T>
    {
        T Populate();
    }
}
