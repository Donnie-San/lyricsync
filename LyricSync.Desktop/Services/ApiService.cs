using LyricSync.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LyricSync.Desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public string Token { get; private set; }

        public ApiService()
        {
            _httpClient = new HttpClient {
                BaseAddress = new Uri("https://localhost:7196")
            };
        }

        public async Task<bool> LoginASync(string email, string password)
        {
            var request = new LoginRequest {
                Email = email,
                Password = password
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Auth/login", content);
            if (!response.IsSuccessStatusCode) return false;

            var responseBody = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });

            Token = loginResponse?.Token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return true;
        }
    }
}
