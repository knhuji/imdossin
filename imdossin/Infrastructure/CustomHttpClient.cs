﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace imdossin.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContext _httpContext;

        public CustomHttpClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string uri) where T : class
        {
            await SetTokenForHttpClient();

            var responseString = await _httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(responseString);

        }

        public async Task<T> GetAsync<T>(string uri) where T : class
        {
            await SetTokenForHttpClient();

            var responseString = await _httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(responseString);

        }

        public async Task PostAsync(string uri, object entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            await SetTokenForHttpClient();

            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error in Creating {entity.GetType().Name}, try later");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(string uri, object entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            await SetTokenForHttpClient();

            var response = await _httpClient.PutAsync(uri, content);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception($"Error in Udpating {entity.GetType().Name}, try later");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string uri)
        {
            await SetTokenForHttpClient();

            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error in deleting object, try later");
            }

            response.EnsureSuccessStatusCode();
        }

        private async Task SetTokenForHttpClient()
        {
            var accessToken = await _httpContext.GetTokenAsync("access_token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
