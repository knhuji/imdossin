using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace imdossin.Infrastructure
{
    public interface IHttpClient
    {

        Task<IEnumerable<T>> GetListAsync<T>(string uri) where T : class;
        Task<T> GetAsync<T>(string uri) where T : class;
        Task PostAsync(string uri, object entity);
        Task PutAsync(string uri, object entity);
        Task DeleteAsync(string uri);

    }
}
