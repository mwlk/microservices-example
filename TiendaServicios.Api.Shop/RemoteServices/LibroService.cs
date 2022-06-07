using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios.Api.Shop.RemoteInterface;
using TiendaServicios.Api.Shop.RemoteModel;

namespace TiendaServicios.Api.Shop.RemoteServices
{
    public class LibroService : ILibroService
    {
        private readonly IHttpClientFactory _factory;
        private readonly ILogger<LibroService> _logger;


        public LibroService(IHttpClientFactory factory, ILogger<LibroService> logger)
        {
            _factory = factory;
            _logger = logger;
        }

        public async Task<(bool result, RemoteBook book, string errorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                var client = _factory.CreateClient("Libros");

                var response = await client.GetAsync($"api/Book/{LibroId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    var result = JsonSerializer.Deserialize<RemoteBook>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());

                return (false, null, e.Message);
            }
        }
    }
}
