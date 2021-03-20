using HRApplicationMVC.Models;
using HRApplicationMVC.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRApplicationMVC.Services
{
    public class ApiAuthService : APIService<AuthDto>
    {
        private static string _UrlParametr = "Api/SignIn";
        public ApiAuthService(IHttpClientFactory httpClientFactory) : base(_UrlParametr, httpClientFactory)
        {
        }
        public async override Task<string> PostAsync(AuthDto data)
        {
            var Headertoken = await base.PostAsync(data);
            if(Headertoken == null)
            {
                return null;
            }
            char[] charsToTrim = { '/', '"' };
            var token = Headertoken.Trim(charsToTrim);
            return token;
        }
    }
}
