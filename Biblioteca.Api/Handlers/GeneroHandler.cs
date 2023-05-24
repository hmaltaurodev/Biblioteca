using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Handlers
{
    public class GeneroHandler
    {
        public static List<Genero> _generos = new List<Genero>();

        public Genero? GetById(long id)
        {
            return _generos.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Post(Genero genero)
        {
            Genero? generoExiste = _generos.Where(x => x.Id == genero.Id)
                                           .FirstOrDefault();

            if (generoExiste != null)
                return false;

            _generos.Add(genero);
            return true;
        }

        public bool Put(Genero genero)
        {
            Genero? generoExiste = _generos.Where(x => x.Id == genero.Id)
                                           .FirstOrDefault();

            if (generoExiste == null)
                return false;

            _generos.Where(x => x.Id == genero.Id)
                    .ToList()
                    .ForEach(x =>
                    {
                        x.Nome = genero.Nome;
                    });
            return true;
        }

        public bool DeleteById(long id)
        {
            return _generos.RemoveAll(x => x.Id == id) > 0;
        }
    }
}
