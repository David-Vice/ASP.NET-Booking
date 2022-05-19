using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<int> Add(T data);
        Task<int> Delete(int id);
        Task<int> Update(T data);
    }
}
