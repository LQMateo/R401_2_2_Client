using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IWSService<T>
    {
        Task<List<T>> DeleteAsync(string nomControleur);
        Task<List<T>> GetDevisesAsync(string nomControleur);
        Task<List<T>> GetSerieAsync(string nomControleur);
        Task<List<T>> PostAsync(string nomControleur);
        Task<List<T>> PutAsync(string nomControleur);
    }
}