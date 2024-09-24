using Microsoft.AspNetCore.Mvc;
using BodegaVinos.Services;
using BodegaVinos.Dtos;
using Services;

namespace BodegaVinos.Controllers
{
    [ApiController]
    [Route("api/wines")]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);
        }

        [HttpGet("{name}")]
        public IActionResult GetWineByName(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null)
            {
                return NotFound("El vino no fue encontrado.");
            }

            return Ok(wine);
        }

        [HttpPost]
        public IActionResult RegisterWine(WineDto wineDto)
        {
            _wineService.RegisterWine(wineDto);
            return Ok("Vino registrado correctamente.");
        }
        // Nuevo método para agregar stock a un vino existente
        [HttpPut("addStock/{name}")]
        public IActionResult AddStock(string name, [FromBody] int quantity)
        {
            try
            {
                _wineService.AddStock(name, quantity);
                return Ok($"Se ha agregado {quantity} unidades al stock del vino '{name}'.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
