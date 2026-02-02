namespace CleanBlog.DataAccess.Repositories.Abstractions.Generic;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    Task<int> SaveChangesAsync();
}
