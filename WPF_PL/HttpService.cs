using System;
using System.Net.Http;

namespace WPF_PL
{
    public static class HttpService
    {
        static HttpClient httpClient;
        static HttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://cryptingup.com/api/");
        }
    }
}
