namespace Risk.Repository
{
    public interface IRepository<T, TDto>
    {
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task Post(TDto entityViewModel);
        Task Put(Guid id, TDto entityViewModel);
    }
}