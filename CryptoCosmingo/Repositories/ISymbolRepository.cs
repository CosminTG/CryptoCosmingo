using CryptoCosmingo.Models;

namespace CryptoCosmingo.Repositories
{
    public interface ISymbolRepository
    {
        Task<List<Symbol>> GetAllAsync();
        Task CreateAsync(Symbol symbol);

    }
}
