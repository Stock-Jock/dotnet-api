using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using APIService.Models;

namespace APIService.Services
{
    public class TypedHttpClient : IHttpClient
    {
        private HttpClient httpClient;
        private IHttpContextAccessor _accessor;
        private IHttpClientFactory _clientFactory;


        public TypedHttpClient(IHttpContextAccessor accessor, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            this.httpClient = httpClient;
            this._accessor = accessor;
            this._clientFactory = clientFactory;
        }

        public async Task<T> Get<T>(string clientName, string uri, Guid id)
        {
            var client = _clientFactory.CreateClient(clientName);
            var response = await client.GetAsync($"{uri}/{id}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private HttpRequestMessage GenerateRequestMessage(string url, HttpMethod method)
        {
            var authHeader = _accessor.HttpContext.Request.Headers["Authorization"];
            var requestMessage = new HttpRequestMessage(method, url);
            if (authHeader.Count == 1)
            {
                //Bearer {token}
                var authHeaderValues = authHeader.ToString()?.Split(" ");
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authHeaderValues[0], authHeaderValues[1]);
            }
            return requestMessage;
        }

        private async Task<HttpResponseMessage> ExecuteRequest(Func<Task<HttpResponseMessage>> toExecute)
        {
            var response = await toExecute.Invoke();
            try
            {
                response.EnsureSuccessStatusCode();
                // Handle success
                return response;
            }
            catch (HttpRequestException)
            {
                // Handle failure
                throw new Exception("Something went wrong");
            }
        }

    }
}