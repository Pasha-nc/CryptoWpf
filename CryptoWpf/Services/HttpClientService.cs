using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWpf.Services
{

    internal class HttpClientService
    {
        public async Task<T> GetData<T>(string uri)
        {
            HttpClient httpClient = new();

            using HttpResponseMessage response = await httpClient.GetAsync(uri);

            T result = default(T);

            try
            {
                result = await response.Content.ReadFromJsonAsync<T>(new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }
            catch
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync(), "Error");
            }

            return result;
        }
    }
}
