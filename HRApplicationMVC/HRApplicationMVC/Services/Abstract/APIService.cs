
using HRApplicationMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRApplicationMVC.Services.Abstraction
{
    public abstract class APIService<T>
    {
        public readonly string lastUrl = default;
        public IHttpClientFactory _clientFactory = default;
        public APIService(string lasturl, IHttpClientFactory clientFactory)
        {
            lastUrl = lasturl;
            _clientFactory = clientFactory;
        }

        public virtual async Task<IEnumerable<T>> GetDataAsync()
        {
            var user = await LoginUserHelperManager.GetCurrentUser();

            var client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            HttpResponseMessage response = await client.GetAsync(lastUrl + "?UserName=" + user.Username);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<T>>();
            }
            else
            {
                return null;
            }
        }
        public virtual async Task<T> GetDataByAsync(string data)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            var client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            HttpResponseMessage response = await client.GetAsync(lastUrl+ "/"+ data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                return default;
            }
        }
        public virtual async Task<string> PostAsync(T data)
        {
            
            var json = JsonConvert.SerializeObject(data);
            var stringdata = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(lastUrl, stringdata);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        public virtual async Task<string> PutAsync(T data, string id)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();

            var client = _clientFactory.CreateClient("meta");
            var json = JsonConvert.SerializeObject(data);
            var stringdata = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            HttpResponseMessage response = await client.PutAsync(lastUrl + "/" + id, stringdata);
            return await response.Content.ReadAsStringAsync();
        }
        public virtual async Task<string> DeleteAsync(string data)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();

            var client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            HttpResponseMessage response = await client.DeleteAsync(lastUrl + "/"+ data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
