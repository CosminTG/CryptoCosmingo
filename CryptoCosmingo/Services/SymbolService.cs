using CryptoCosmingo.DTOs;
using CryptoCosmingo.Models;
using CryptoCosmingo.Repositories;

namespace CryptoCosmingo.Services
{
    public class SymbolService : ISymbolService
    {
        private readonly ISymbolRepository _repo;

        public SymbolService(ISymbolRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SymbolDTO>> GetAllAsync()
        {
            var symbols = await _repo.GetAllAsync();

            return symbols.Select(x => new SymbolDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task CreateAsync(CreateSymbolDTO dto)
        {
            var symbol = new Symbol
            {
                Name = dto.Name
            };

            await _repo.CreateAsync(symbol);
        }
    }
}
