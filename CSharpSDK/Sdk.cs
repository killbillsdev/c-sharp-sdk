using System;
using System.Net.Http;

namespace CSharpSDK
{
    public partial class Killbills_sdk
    {
        private readonly HttpClient _httpClient;
        private const string KILLBILLS_STORES_API_URL = "https://yourapiurl.com";

        public Killbills_sdk()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(KILLBILLS_STORES_API_URL) };
        }
    }
}
