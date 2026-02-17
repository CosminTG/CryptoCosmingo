using CryptoCosmingo.Models;

namespace CryptoCosmingo.Repositories
{
    public interface ISymbolRepository
    {
        Task<List<Symbol>> GetCryptoSymbolAsyncDB(string cryptosymbol);
        Task CreateAsync(Symbol symbol);

    }
}
