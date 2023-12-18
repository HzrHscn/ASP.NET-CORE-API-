using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult AssignmentList()
        {
            var values = _assignmentService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAssignment(Assignment assignment)
        {
            _assignmentService.TInsert(assignment);
            return Ok("Görev eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteAssignment(int id)
        {
            var values = _assignmentService.TGetById(id);
            _assignmentService.TDelete(values);
            return Ok("Görev silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAssignment(Assignment assignment)
        {
            _assignmentService.TUpdate(assignment);
            return Ok("Görev güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var values = _assignmentService.TGetById(id);
            return Ok(values);
        }
    }
}
