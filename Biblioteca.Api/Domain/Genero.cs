using System.Text.Json.Serialization;

namespace Biblioteca.Api.Domain
{
    public class Genero
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
