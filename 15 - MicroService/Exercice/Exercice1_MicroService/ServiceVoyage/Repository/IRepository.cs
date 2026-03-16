namespace ServiceVoyage.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create (T entity);
    }
}
