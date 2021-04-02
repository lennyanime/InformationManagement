using InformationManagement.Infraestructura.Transversal.Exceptions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InformationManagement.Infraestructura.Transversal.GenericClass
{
    public class HttpBaseClientGenericClass<T> : IHttpBaseClientGenericClass<T> where T : class
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;

        public HttpBaseClientGenericClass(string baseUrl, HttpClient client)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new UriFormatException();

            _baseUrl = baseUrl;
            _client = client ?? throw new HttpClientNotDefinedException();
            _client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<T> Get(string path, string request)
        {
            ValidatePath(path);

            var response = await _client.GetAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public T Patch(string path, T request)
        {
            ValidatePath(path);
            throw new NotImplementedException();
        }

        public async Task<T> Post(string path, T request)
        {
            ValidatePath(path);
            var stringRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsync(path, stringRequest).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public T Put(string path, T request)
        {
            ValidatePath(path);
            throw new NotImplementedException();
        }

        private void ValidatePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException($"Parameter: {nameof(path)} required");
        }
    }
}

