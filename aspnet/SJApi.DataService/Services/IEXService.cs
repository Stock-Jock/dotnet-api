using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SJApi.DataService.Interfaces;
using SJApi.ObjectModel.Models;
using SJAPI.ObjectModel.Models;

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

        public async Task<List<Object>> RetrieveSymbols()
        {
            JArray stockList = await _client.Get<JArray>(_sc.IEXClient, _sc.IEXUrl);

            List<Object> newStockList = stockList.ToObject<List<Object>>();

            return newStockList;
        }
    }
}