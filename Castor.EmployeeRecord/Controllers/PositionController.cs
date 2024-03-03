using Castor.EmployeeRecord.Models;
using Castor.EmployeeRecord.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Castor.EmployeeRecord.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet("GetPosition")]
        public IActionResult GetPosition()
        {
            List<Position> positions = new List<Position>();
            positions = _positionService.GetPositions();
            return positions.Count != 0 ? Ok(positions) : BadRequest("No tiene datos para la posición");
        }
    }
}
