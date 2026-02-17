using CryptoCosmingo.DTOs;
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

        public async Task<List<SymbolDTO>> GetCryptoSymbolAsync(string cryptosymbol)
        {
            var symbols_service = await _repo.GetCryptoSymbolAsyncDB(cryptosymbol);

            return symbols_service.Select(x => new SymbolDTO
            {
                //Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async task createasync(createsymboldto dto)
        {
            var symbol = new symbol
            {
                name = dto.name
            };
            await _repo.createasync(symbol);
        }
    }
}
