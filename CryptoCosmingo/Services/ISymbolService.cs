using CryptoCosmingo.DTOs;

namespace CryptoCosmingo.Services
{
    public interface ISymbolService
    {
        Task<List<SymbolDTO>> GetCryptoSymbolAsync(string cryptosymbol);
        Task<SymbolListResponseDTO> GetExchangeInfoAsync();
        //Task CreateAsync(CreateSymbolDTO dto);
    }
}