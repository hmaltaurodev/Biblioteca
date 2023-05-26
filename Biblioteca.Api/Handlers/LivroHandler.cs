using Biblioteca.Api.Domain;
using Biblioteca.Api.Enums;

namespace Biblioteca.Api.Handlers
{
    public class LivroHandler
    {
        public static List<Livro> _livros = new List<Livro>();

        public Livro? GetById(long id)
        {
            return _livros.Where(x => x.Id == id).FirstOrDefault();
        }

        public LivroValidate Post(Livro livro)
        {
            Livro? livroExiste = _livros.Where(x => x.Id == livro.Id)
                                        .FirstOrDefault();

            if (livroExiste != null)
                return LivroValidate.LivroExiste;

            Genero? genero = GeneroHandler
                             ._generos.Where(x => x.Id == livro.GeneroId)
                             .FirstOrDefault();

            if (genero == null)
                return LivroValidate.GeneroNaoExiste;

            Autor? autor = AutorHandler
                           ._autores.Where(x => x.Id == livro.AutorId)
                           .FirstOrDefault();

            if (autor == null)
                return LivroValidate.AutorNaoExiste;

            livro.Genero = genero;
            livro.Autor = autor;

            _livros.Add(livro);
            return LivroValidate.Ok;
        }

        public LivroValidate Put(Livro livro)
        {
            Livro? livroExiste = _livros.Where(x => x.Id == livro.Id)
                                        .FirstOrDefault();

            if (livroExiste == null)
                return LivroValidate.LivroNaoExiste;

            Genero? genero = GeneroHandler
                             ._generos.Where(x => x.Id == livro.GeneroId)
                             .FirstOrDefault();

            if (genero == null)
                return LivroValidate.GeneroNaoExiste;

            Autor? autor = AutorHandler
                           ._autores.Where(x => x.Id == livro.AutorId)
                           .FirstOrDefault();

            if (autor == null)
                return LivroValidate.AutorNaoExiste;

            _livros.Where(x => x.Id == livro.Id)
                   .ToList()
                   .ForEach(x =>
                   {
                       x.Titulo = livro.Titulo;
                       x.GeneroId = livro.GeneroId;
                       x.Genero = genero;
                       x.AutorId = livro.AutorId;
                       x.Autor = autor;
                   });
            return LivroValidate.Ok;
        }

        public bool DeleteById(long id)
        {
            return _livros.RemoveAll(x => x.Id == id) > 0;
        }
    }
}
