using CryptoCosmingo.Models;
using CryptoCosmingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCosmingo.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class SymbolsController : ControllerBase
    {
        private readonly ISymbolService _repo;

        public SymbolsController(ISymbolService repo)
        {
            _repo = repo;
        }

        [HttpGet("/symbols/{cryptosymbol}")]
        public async Task<IActionResult> GetCryptoSymbol(string cryptosymbol)
        {
            var symbols_controller = await _repo.GetCryptoSymbolAsync(cryptosymbol);
            return Ok(symbols_controller);
        }
        [HttpGet("exchangeInfo")]
        public async Task<IActionResult> GetExchangeInfo()
        {
            var getexchangeinfo = await _repo.GetExchangeInfoAsync();
            return Ok(getexchangeinfo);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Symbol symbol)
        {
            //await _repo.CreateAsync(symbol);
            return Ok("Symbol created successfully");
        }
    }
}