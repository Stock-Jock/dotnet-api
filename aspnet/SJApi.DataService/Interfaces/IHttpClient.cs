using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIService.Services
{
    public interface IHttpClient
    {
        Task<T> Get<T>(string clientName, string uri, Guid id);
    }
}