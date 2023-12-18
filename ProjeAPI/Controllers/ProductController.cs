using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjeUI.Models.Personel;
using ProjeUI.Models.Product;
using System.Net.Http;
using System.Text;

namespace ProjeUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //ÜRÜN LİSTELEME
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7273/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductViewModel>>(jsondata);
                return View(values);
            }
            return View();
        }
        //ÜRÜN EKLEME
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            try
            {
                // Null kontrolü
                if (productViewModel == null)
                {
                    return BadRequest("Invalid input");
                }

                // ViewModel'den Entity'e dönüşüm yap
                var product = new Product
                {
                    Name = productViewModel.Name,
                    Category = productViewModel.Category,
                    Brand = productViewModel.Brand,
                    Quantity = productViewModel.Quantity,
                    Description = productViewModel.Description,
                    ImgUrl = productViewModel.ImgUrl,
                    Status = productViewModel.Status
                };

                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(product);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:7273/api/Product", stringContent);

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
        //ÜRÜN GÜNCELLEME
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7273/api/Product/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductViewModel>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            try
            {
                // Null kontrolü
                if (productViewModel == null)
                {
                    return BadRequest("Invalid input");
                }

                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(productViewModel);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync("https://localhost:7273/api/Product", stringContent);

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
                    return BadRequest("API request failed");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunu işle
                return BadRequest("API request failed");
            }
        }
        //ÜRÜN SİLME
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync("https://localhost:7273/api/Product" + id);

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
                    return BadRequest("API request failed");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunu işle
                return BadRequest("API request failed");
            }
        }


    }
}
