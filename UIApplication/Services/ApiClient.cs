using Core.Models.OrderAggregate;
using Core.Models.ProductAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UIApplication.Services
{
    public class ApiClient
    {
        private readonly string resourceId;
        private readonly string authority;
        private readonly string appId;
        private readonly string appSecret;
        private readonly HttpClient client;
        private bool tokenSet = false;

        public ApiClient(HttpClient client, IConfiguration configuration)
        {
            resourceId = configuration["AzureAd:ShoppingDDDServicesResourceId"];
            authority = $"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}";
            appId = configuration["AzureAd:ClientId"];
            appSecret = configuration["AzureAd:ClientSecret"];
            this.client = client;
            this.client.BaseAddress = new Uri(configuration["AzureAd:ShoppingDDDServicesBaseAddress"]);
        }

        public async Task<List<Product>> GetProducts()
        {
            await SetToken();
            var response = await client.GetAsync("api/products");
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode}");
            }

            var content = response.Content;
            var contentAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(contentAsString);
        }

        public async Task Order(Order order)
        {
            var response = await client.PostAsJsonAsync<Order>("api/orders", order);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode}");
            }
        }

        public async Task SetToken()
        {
            if(!tokenSet)
            {
                var authContext = new AuthenticationContext(authority);
                var credentials = new ClientCredential(appId, appSecret);
                var authResult = await authContext.AcquireTokenAsync(resourceId, credentials);
                var token = authResult.AccessToken;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                tokenSet = true;
            }
        }
    }
}
