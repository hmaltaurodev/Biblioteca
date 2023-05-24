using System.Text.Json.Serialization;

namespace Biblioteca.Api.Domain
{
    public class Livro
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("genero-id")]
        public long GeneroId { get; set; }

        [JsonPropertyName("genero")]
        public Genero Genero { get; set; }

        [JsonPropertyName("autor-id")]
        public long AutorId { get; set; }

        [JsonPropertyName("autor")]
        public Autor Autor { get; set; }

        [JsonPropertyName("alugado")]
        public bool Alugado { get; set; } = false;
    }
}
