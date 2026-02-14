using CryptoCosmingo.DTOs;

namespace CryptoCosmingo.Services
{
    public interface ISymbolService
    {
        Task<List<SymbolDTO>> GetAllAsync();
        Task CreateAsync(CreateSymbolDTO dto);
    }
}
