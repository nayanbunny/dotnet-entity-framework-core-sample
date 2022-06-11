using DotNet.EFCore.DatabaseFirst.MvcApp.Data;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Repository
{
    /// <summary>
    /// Generic Repository to perform CRUD operations on database using Entity Framework DB Context
    /// </summary>
    /// <typeparam name="T">Generic Type Class</typeparam>
    public class GenericRepository<T> where T : class
    {
        /// <summary>
        /// Entity Framework DB Context
        /// </summary>
        private readonly EFCoreDBFirstDatabaseContext _dbContext;

        /// <summary>
        /// Contructor to Initialize Generic Repository Class
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public GenericRepository(EFCoreDBFirstDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Method to perform Create Entity operation.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>true if success; otherwise false</returns>
        public bool CreateEntity(object? entity)
        {
            if (entity == null)
                return false;
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// Method to perform Get Entity operation.
        /// </summary>
        /// <returns>entity list</returns>
        public List<T> GetEntityData()
        {
            return _dbContext.Set<T>().ToList();
        }

        /// <summary>
        /// Method to perform Update Entity operation.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>true if success; otherwise false</returns>
        public bool UpdateEntity(object? entity)
        {
            if (entity == null)
                return false;
            _dbContext.Update((T)entity);
            _dbContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// Method to perform Delete Entity operation.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>true if success; otherwise false</returns>
        public bool DeleteEntity(object? entity)
        {
            if (entity == null)
                return false;
            _dbContext.Remove((T)entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
