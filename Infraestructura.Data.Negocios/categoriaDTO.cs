using Dominio.Entidad.Negocios.Abstraccion;
using Dominio.Entidad.Negocios.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace Infraestructura.Data.Negocios
{
    public class categoriaDTO : ICategoriaRepositorio
    {

        private readonly static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        public IEnumerable<Categoria> GetAll()
        {
            var listado = new List<Categoria>();
            var sp = "usp_ListarCategoria_AquiseOscar";


            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Categoria categoria = new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["Idcategoria"]),
                            NombreCategoria = Convert.ToString(dr["Nombrecategoria"])
                        };
                        listado.Add(categoria);
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listado;
        }

    }
}
