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
    public class ApiUserService : APIService<User>
    {
        private static string _UrlParametr = "Api/User";
        public ApiUserService(IHttpClientFactory httpClientFactory) : base(_UrlParametr, httpClientFactory)
        {
        }
        public async override Task<string> PostAsync(User data)
        {
            var password = data.Password;
            var json = JsonConvert.SerializeObject(data);
            var stringdata = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("meta");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(lastUrl+"?Password="+password, stringdata);
            if (response.IsSuccessStatusCode) {
                var Headertoken = await response.Content.ReadAsStringAsync();
                char[] charsToTrim = { '/', '"' };
                var token = Headertoken.Trim(charsToTrim);
                await LoginUserHelperManager.LoginUser(new SignedInDto { Username = data.UserName, Token = token}) ;
                return "Succes";
            }
            else
            {
                return null;
            }


        }
    }
}
