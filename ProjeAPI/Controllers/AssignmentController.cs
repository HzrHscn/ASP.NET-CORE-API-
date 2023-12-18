using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjeUI.Models.Assignment;
using ProjeUI.Models.Personel;
using ProjeUI.Models.Product;

namespace ProjeUI.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AssignmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //ASSIGNMENT LİSTELEME ama producttan name ve barcode çekiyor personelden de name çekiyor 
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7273/api/Assignment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var assignments = JsonConvert.DeserializeObject<List<AssignmentViewModel>>(jsondata);

                foreach (var assignment in assignments)
                {
                    // Her bir Assignment için ayrı API çağrısı yaparak Product ve Personel bilgilerini al
                    var productResponse = await client.GetAsync($"https://localhost:7273/api/Product/{assignment.productID}");
                    var productJsonData = await productResponse.Content.ReadAsStringAsync();
                    assignment.Product = JsonConvert.DeserializeObject<ProductViewModel>(productJsonData);

                    var personelResponse = await client.GetAsync($"https://localhost:7273/api/Personel/{assignment.personelID}");
                    var personelJsonData = await personelResponse.Content.ReadAsStringAsync();
                    assignment.Personel = JsonConvert.DeserializeObject<PersonelViewModel>(personelJsonData);
                }

                return View(assignments);
            }

            return View();
        }

        //ASSIGNMENT EKLEME
    }
}
