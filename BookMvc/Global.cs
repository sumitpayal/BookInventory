using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookMvc
{
    public static class Global
    {
        public static HttpClient webclient = new HttpClient();
        static Global()
        {
            webclient.BaseAddress = new Uri("https://localhost:44358/api/");
            webclient.DefaultRequestHeaders.Clear();
            webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}