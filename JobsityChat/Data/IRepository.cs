using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsityChat.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> GetAll();
        void Add(T entity);
    }
}
