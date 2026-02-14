using CryptoCosmingo.Models;
using CryptoCosmingo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCosmingo.Controllers
{
    [ApiController]
    [Route("api/symbols")]
    public class SymbolsController : ControllerBase
    {
        private readonly ISymbolRepository _repo;

        public SymbolsController(ISymbolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var symbols = await _repo.GetAllAsync();
            return Ok(symbols);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Symbol symbol)
        {
            await _repo.CreateAsync(symbol);
            return Ok("Symbol created successfully");
        }
    }
}