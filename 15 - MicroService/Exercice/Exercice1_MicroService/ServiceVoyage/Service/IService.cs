namespace ServiceVoyage.Service
{
    public interface IService<Tsend,Treceive>
    {
        Tsend GetById(int id);
        List<Tsend> GetAll();
        Tsend Create(Treceive entity);
    }
}
