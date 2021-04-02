using InformationManagement.Aplication.Dto.DataTransfer_Object;
using InformationManagement.Infraestructura.Transversal.Exceptions;
using InformationManagement.Infraestructura.Transversal.GenericMethods.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InformationManagement.Infraestructura.Transversal.GenericMethods
{
    public class HttpGenericBaseClient : IHttpGenericBaseClient
    {
        private readonly HttpClient _client;

        public HttpGenericBaseClient(IOptions<HttpClientSettings> settings, HttpClient client)
        {
            if (settings.Value.GetServiceUrl() == null)
                throw new UriFormatException();

            _client = client ?? throw new HttpClientNotDefinedException();
            _client.BaseAddress = settings.Value.GetServiceUrl();
        }

        public async Task<T> Get<T>(string path, string request) where T : class
        {
            ValidatePath(path);

            var response = await _client.GetAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public T Patch<T>(string path, T request) where T : DataTransferObject
        {
            ValidatePath(path);
            throw new NotImplementedException();
        }

        public async Task<TResponse> Post<TResponse, TRequest>(string path, TRequest request) where TResponse : DataTransferObject
        {
            ValidatePath(path);
            var stringRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsync(path, stringRequest).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public T Put<T>(string path, T request) where T : DataTransferObject
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
