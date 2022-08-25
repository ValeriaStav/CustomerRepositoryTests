namespace CustomerManagement.Interfaces
{
    interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(string entity);
        void Update(TEntity entity);
        void Delete(string entity);
    }
}