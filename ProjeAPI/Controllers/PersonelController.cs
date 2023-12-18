using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjeUI.Models.Personel;
using System.Net.Http;
using System.Text;

namespace ProjeUI.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //PERSONEL LİSTELEME
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7273/api/Personel");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PersonelViewModel>>(jsondata);
                return View(values);
            }
            return View();
        }
        //PERSONEL EKLEME
        public async Task<IActionResult> Create(PersonelViewModel personelViewModel)
        {
            try
            {
                // Null kontrolü
                if (personelViewModel == null)
                {
                    return BadRequest("Invalid input");
                }

                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(personelViewModel);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:7273/api/Personel", stringContent);

                // HttpResponseMessage kontrolü
                if (responseMessage == null)
                {
                    return BadRequest("API request failed");
                }

                // StatusCode kontrolü
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Hata durumunu işle
                    var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                    ViewBag.ErrorMessage = errorMessage;
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Diğer hata durumları için genel bir hata mesajı
                ViewBag.ErrorMessage = "An error occurred while processing your request." + ex;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7273/api/Personel/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunu işle
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7273/api/Personel/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<PersonelViewModel>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonelViewModel personelViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(personelViewModel);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7273/api/Personel", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunu işle
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }
        }
    }
}
