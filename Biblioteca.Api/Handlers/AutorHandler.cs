using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Handlers
{
    public class AutorHandler
    {
        public static List<Autor> _autores = new List<Autor>();

        public Autor? GetById(long id)
        {
            return _autores.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Post(Autor autor)
        {
            Autor? autorExiste = _autores.Where(x => x.Id == autor.Id)
                                         .FirstOrDefault();

            if (autorExiste != null)
                return false;

            _autores.Add(autor);
            return true;
        }

        public bool Put(Autor autor)
        {
            Autor? autorExiste = _autores.Where(x => x.Id == autor.Id)
                                         .FirstOrDefault();

            if (autorExiste == null)
                return false;

            _autores.Where(x => x.Id == autor.Id)
                    .ToList()
                    .ForEach(x =>
                    {
                        x.Nome = autor.Nome;
                        x.NomeArtistico = autor.NomeArtistico;
                    });
            return true;
        }

        public bool DeleteById(long id)
        {
            return _autores.RemoveAll(x => x.Id == id) > 0;
        }
    }
}
