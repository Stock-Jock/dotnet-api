using System.Collections;
using System.Threading.Tasks;
using SJApi.DataService.Interfaces;
using SJApi.ObjectModel.Models;

namespace SJApi.DataService.Services
{
    public class IEXService : IIEXService
    {
        private readonly IHttpClient _client;
        private readonly ServiceConfig _sc;

        public IEXService(IHttpClient client, ServiceConfig sc)
        {
            _client = client;
            _sc = sc;
        }

        public async Task<IEnumerable> RetrieveSymbolsIEX()
        {
            return await _client.Get<IEnumerable>(_sc.IEXClient, _sc.IEXUrl);
        }
    }
}