using System.Collections.Generic;

namespace WindowsFormsApp1.repository
{
    public interface IRepository<ID, T>
    {
        /*
  *
  * @param id -the id of the entity to be returned
  *           id must not be null
  * @return an {TE} entity with the given id
  * @throws IllegalArgumentException
  *                  if id is null.
  */
        T FindById(ID id);
    
        /*
         *
         * @return all entities
         */
        IEnumerable<T> FindAll();
        /*
         *
         * @param entity
         *         entity must be not null
         * @throws IllegalArgumentException
         *             if the given entity is null.     *
         */
        void Save(T entity);
        /*
         *  removes the entity with the specified id
         * @param id
         *      id must be not null
         * @throws IllegalArgumentException
         *                   if the given id is null.
         */
        void Delete(T entity);
        /*
         * @param id
         * @param entity entity must not be null
         * @throws IllegalArgumentException if the given entity is null.
         */
        void Update(ID id, T entity);

        ICollection<T> GetAll();
    }
}