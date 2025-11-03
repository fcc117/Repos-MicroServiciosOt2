using LoginService.Aplication.Interfaces.Menu;
using LoginService.Aplication.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace LoginService.Infrastructure.Services.Menu
{

    public class MenuHttpClient : IMenuService
    {
        private readonly HttpClient _httpClient;

        public MenuHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<MenuResponseDto>> ObtenerMenuPorEmpleadoAsync(string fcNumeroEmpleado, string token)
        {
            string url = "/ApiGateway/Menu/ObtenerMenu";//"/MenuService/api/Menu/ObtenerMenu"; //http://localhost:8009/Menuservice/api/Menu/ObtenerMenu
            var payload = new { fcNumeroEmpleado };

            var jsonContent = JsonContent.Create(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = jsonContent;

            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<EntResultado<MenuResponseDto>>();

            return result?.datalist ?? new List<MenuResponseDto>();

        }
    }
}
