using Matrix.Common.Extensions;
using Matrix.Common.Helpers;
using Matrix.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            var rotationResult = JsonConvert.SerializeObject(rotationService.ClockwiseMatrixRotation(incommingMatrix));
            return Ok(rotationResult);
        }

        [HttpGet("anti-clockwise-rotation")]

        public IActionResult BackWiseMatrixRotation()
        {
            if (incommingMatrix == null)
            {
                return BadRequest("Invalid matrix data");
            }

            var rotationResult = JsonConvert.SerializeObject(rotationService.AnticlockwiseMatrixRotation(incommingMatrix));
            return Ok(rotationResult);
        }

        [HttpPost("store")]
        public IActionResult StoreMatrix([FromBody] BodyHelper bodyData)
        {
            var parsedData = bodyData.matrix.ConvertToArray();
            if (parsedData == null)
            {
                return BadRequest("Invalid input matrix data");
            }

            incommingMatrix = parsedData;
            return Ok(true);
        }
    }
}