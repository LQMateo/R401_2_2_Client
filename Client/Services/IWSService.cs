using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IWSService<T>
    {
        Task<System.Net.Http.HttpResponseMessage> DeleteAsync(string nomControleur);
        Task<List<T>> GetAsync(string nomControleur);
        Task<List<T>> GetSerieAsync(string nomControleur);
        Task<System.Net.Http.HttpResponseMessage> PostAsync(string nomControleur, T objet);
        Task<System.Net.Http.HttpResponseMessage> PutAsync(string nomControleur, T objet);
    }
}