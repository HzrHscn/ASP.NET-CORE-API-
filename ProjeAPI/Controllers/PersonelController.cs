using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet]
        public IActionResult PersonelList()
        {
            var values = _personelService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            _personelService.TInsert(personel);
            return Ok("Personel eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePersonel(int id)
        {
            var values = _personelService.TGetById(id);
            _personelService.TDelete(values);
            return Ok("Personel silindi.");
        }
        [HttpPut]
        public IActionResult UpdatePersonel(Personel personel)
        {
            _personelService.TUpdate(personel);
            return Ok("Personel güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonelById(int id)
        {
            var values = _personelService.TGetById(id);
            return Ok(values);
        }
    }
}
