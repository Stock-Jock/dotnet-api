using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

        public async Task<Stock[]> RetrieveSymbols()
        {   
            return await _client.Get<Stock[]>(_sc.IEXClient, _sc.IEXUrl);
        }
    }
}