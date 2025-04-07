using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    public class ApiClient
    {
        private static readonly Lazy<ApiClient> _instance = new Lazy<ApiClient>(() => new ApiClient());

        private readonly HttpClient _httpClient;

        private ApiClient()
        {
            _httpClient = new HttpClient();
            // Optionally set default headers here
        }

        public static ApiClient Instance => _instance.Value;

        public async Task<string> PostAsync(string path, object postContent)
        {
            string url = $"{LauncherClient.GetAPIUrl()}{path}";
            string jsonContent = JsonConvert.SerializeObject(postContent);
            try
            {
                using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                using (var response = await _httpClient.PostAsync(url, content))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Request error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }
    }
}
