using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairRequestController : ControllerBase
    {
        private readonly IRepairRequestService _repairRequestService;

        public RepairRequestController(IRepairRequestService repairRequestService)
        {
            _repairRequestService = repairRequestService;
        }
        [HttpGet]
        public IActionResult RepairRequestList()
        {
            var values = _repairRequestService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRepairRequest(RepairRequest repairRequest)
        {
            _repairRequestService.TInsert(repairRequest);
            return Ok("Arıza kaydı eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteRepairRequest(int id)
        {
            var values = _repairRequestService.TGetById(id);
            _repairRequestService.TDelete(values);
            return Ok("Arıza kaydı silindi.");
        }
        [HttpPut]
        public IActionResult UpdateRepairRequest(RepairRequest repairRequest)
        {
            _repairRequestService.TUpdate(repairRequest);
            return Ok("Arıza kaydı güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetRepairRequestById(int id)
        {
            var values = _repairRequestService.TGetById(id);
            return Ok(values);
        }
    }
}
