using System.Text.Json.Serialization;

namespace CryptoCosmingo.DTOs
{
    public class CreateSymbolDTO
    {
        public string Name { get; set; }
    }

    // DTO para recibir la respuesta de Binance
    public class ExchangeInfoResponse
    {
        public List<ExchangeSymbol> Symbols { get; set; }
    }

    public class ExchangeSymbol
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    // DTO para devolver al usuario (NUEVO)
    public class SymbolListResponseDTO
    {
        public int Total { get; set; }
        public List<SymbolDTO> Symbols { get; set; }
    }
}
