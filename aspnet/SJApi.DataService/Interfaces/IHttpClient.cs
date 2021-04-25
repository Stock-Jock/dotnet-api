using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJApi.DataService.Interfaces
{
    public interface IHttpClient
    {
        Task<T> Get<T>(string clientName, string uri);
    }
}