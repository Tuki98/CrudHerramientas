using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioGet<T> where T : class
    {
        IEnumerable<T> GetAll();

       
    }
}
