﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioCRUD<T> where T : class
    {
        string Create(T entity);
        string Update(T entity);
        string Delete(int id);
        T Find(int id);
    }
}
