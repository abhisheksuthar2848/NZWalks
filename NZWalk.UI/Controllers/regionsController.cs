using Microsoft.AspNetCore.Mvc;
using NZWalk.UI.Models;
using NZWalk.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NZWalk.UI.Controllers
{
    public class regionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public regionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            List<RegionDTO> responce = new List<RegionDTO>();
            try
            {

                // get all region information from web api
                var client = httpClientFactory.CreateClient();
                var httpResponceMessage = await client.GetAsync("https://localhost:7123/api/regions");

                httpResponceMessage.EnsureSuccessStatusCode();

                var stringResponceBody = await httpResponceMessage.Content.ReadAsStringAsync();

                //ViewBag.Responce=stringResponceBody;

                responce.AddRange(await httpResponceMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());
            }
            catch (Exception ex)
            {

                //throw  ;
            }

            return View(responce);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {

            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7123/api/Regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };


            var httpresponceMessage = await client.SendAsync(httpRequestMessage);


            httpresponceMessage.EnsureSuccessStatusCode();

            var Response = await httpresponceMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (Response is not null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responce = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7123/api/regions/{id.ToString()}");
            if (responce is not null)
            {
                return View(responce);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO regionDTO)
        {
            var client = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7123/api/Regions/{regionDTO.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDTO), Encoding.UTF8, "application/json")
            };

            var httpResponceMessage= await client.SendAsync(httpRequestMessage);
            httpResponceMessage.EnsureSuccessStatusCode();

            var responce = await httpResponceMessage.Content.ReadFromJsonAsync<RegionDTO>();
            if (responce is not null)
            {
                return RedirectToAction("edit","Regions");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responce = await client.DeleteAsync($"https://localhost:7123/api/regions/{id.ToString()}"); 
            if (responce is not null)
            {
                return RedirectToAction("Index");
            }
            return View(null);
        }
    }
}
