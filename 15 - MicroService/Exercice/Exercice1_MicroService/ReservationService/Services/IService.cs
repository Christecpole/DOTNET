namespace ReservationService.Services
{
    public interface IService<TSend,TReceive>
    {
        Task<TSend> GetById(int id);
        Task<List<TSend>> GetAll();
        Task<TSend> Create(TReceive receive);
    }
}
