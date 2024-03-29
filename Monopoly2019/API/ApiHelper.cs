﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Monopoly2019.API
{
   public static class ApiHelper // Singleton
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient { BaseAddress = new Uri("https://localhost:44313/") };
            //  ApiClient = new HttpClient { BaseAddress = new Uri("http://monopolisgame.azurewebsites.net/") };
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
