using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwapiMVC.Models;
using System.Text.Json.Serialization;

namespace SwapiMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly HttpClient _httpClient;
        public PeopleController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("swapi");
        }
        public async Task<IActionResult> Index([FromQuery] string page)
        {
            string route = $"people?page={page ?? "1"}";
            HttpResponseMessage response = await _httpClient.GetAsync(route);

            var viewModel = await response.Content.ReadFromJsonAsync<ResultsViewModel<PeopleViewModel>>();

                return View(viewModel);
        }
    }
}