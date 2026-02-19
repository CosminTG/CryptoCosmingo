using CryptoCosmingo.DTOs;
using CryptoCosmingo.Repositories;

namespace CryptoCosmingo.Services
{
    public class SymbolService : ISymbolService
    {
        private readonly ISymbolRepository _repo;
        private readonly HttpClient _httpClient;

        public SymbolService(ISymbolRepository repo, HttpClient httpClient)
        {
            _repo = repo;
            _httpClient = httpClient;
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

        public async Task<SymbolListResponseDTO> GetExchangeInfoAsync()
        {
            var url = "https://api.binance.com/api/v3/exchangeInfo";
            var data = await _httpClient.GetFromJsonAsync<ExchangeInfoResponse>(url);

            if (data == null || data.Symbols == null)
                return new SymbolListResponseDTO
                {
                    Total = 0,
                    Symbols = new List<SymbolDTO>()
                };

            // Filtra y convierte a SymbolDTO
            var symbols = data.Symbols
                .Where(x => x.Status == "TRADING")
                .Select(x => new SymbolDTO
                {
                    Name = x.Symbol
                })
                .ToList();

            return new SymbolListResponseDTO
            {
                Total = symbols.Count,
                Symbols = symbols
            };
        }




        //public async task createasync(createsymboldto dto)
        //{
        //    var symbol = new symbol
        //    {
        //        name = dto.name
        //    };
        //    await _repo.createasync(symbol);
        //}
    }
}
