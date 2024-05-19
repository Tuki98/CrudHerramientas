using Dominio.Entidad.Negocios.Entidad;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocios.Abstraccion
{
    public interface IHerramientaRepositorio    : IRepositorioGet<Herramienta>, IRepositorioCRUD<Herramienta>
    {
    }
}
