using HRApplicationMVC.Models;
using HRApplicationMVC.Services.Abstraction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRApplicationMVC.Services
{
    public class ApiEmployeeService : APIService<Employee>
    {
        private static string _UrlParametr = "Api/Employee";
        public ApiEmployeeService(IHttpClientFactory httpClientFactory) : base(_UrlParametr, httpClientFactory)
        {
        }
        public async override Task<string> PostAsync(Employee data)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();

            var json = JsonConvert.SerializeObject(data);
            var stringdata = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            var response = await client.PostAsync(lastUrl + "?UserName=" + user.Username, stringdata);
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
