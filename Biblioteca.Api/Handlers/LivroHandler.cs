using Biblioteca.Api.Domain;

namespace Biblioteca.Api.Handlers
{
    public class LivroHandler
    {
        public static List<Livro> _livros = new List<Livro>();

        public Livro? GetById(long id)
        {
            return _livros.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
