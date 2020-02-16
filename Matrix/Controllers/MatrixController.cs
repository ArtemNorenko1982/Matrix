using Matrix.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Matrix.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        private readonly IRotationService rotationService;
        private static int[,] incommingMatrix;

        public MatrixController(IRotationService rotationService)
        {
            this.rotationService = rotationService;
        }

        [HttpGet("clockwise-rotation")]

        public IActionResult ClockWiseMatrixRotation()
        {
            if (incommingMatrix == null)
            {
                return BadRequest("Invalid matrix data");
            }

            var rotationResult = rotationService.ClockwiseMatrixRotation(incommingMatrix);
            return Ok(rotationResult);
        }

        [HttpGet("anti-clockwise-rotation")]

        public IActionResult BackWiseMatrixRotation()
        {
            if (incommingMatrix == null)
            {
                return BadRequest("Invalid matrix data");
            }

            var rotationResult = rotationService.ClockwiseMatrixRotation(incommingMatrix);
            return Ok(rotationResult);
        }

        [HttpPost("store")]
        public IActionResult StoreMatrix(string incomingMatrix)
        {
            //TODO:
            var t = incomingMatrix;
            //incommingMatrix = incomingMatrix;
            return Ok();
        }
    }
}