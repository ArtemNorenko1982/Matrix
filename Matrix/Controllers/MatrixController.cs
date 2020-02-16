using Matrix.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        private readonly IRotationService rotationService;
        private int[,] incommingMatrix;
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
        public IActionResult StoreMatrix(FromBodyAttribute bodyAttribute)
        {
            //TODO:
            //incommingMatrix = bodyAttribute --> getMatrix()
            return Ok();
        }

        [HttpPost("generate")]
        public IActionResult GenerateRandomMatrix(FromBodyAttribute bodyAttribute)
        {
            //TODO:
            //incommingMatrix = bodyAttribute --> getMatrix()
            return Ok();
        }
    }
}