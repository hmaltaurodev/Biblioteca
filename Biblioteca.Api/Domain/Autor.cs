using System.Text.Json.Serialization;

namespace Biblioteca.Api.Domain
{
    public class Autor
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("nome_artistico")]
        public string NomeArtistico { get; set; }
    }
}
