using Dominio.Entidad.Negocios.Abstraccion;
using Dominio.Entidad.Negocios.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Infraestructura.Data.Negocios
{
    public class herramientaDTO : IHerramientaRepositorio
    {
        private readonly static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public string Create(Herramienta herramienta)
        {
            string mensaje = "";
            var sp = "usp_InsertarHerramienta_AquiseOscar";

            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@desHer", herramienta.IdHer);
                    cmd.Parameters.AddWithValue("@medHer", herramienta.MedHer);
                    cmd.Parameters.AddWithValue("@idcategoria", herramienta.IdCategoria);
                    cmd.Parameters.AddWithValue("@preUni", herramienta.PreUni);
                    cmd.Parameters.AddWithValue("@stock", herramienta.Stock);

                    var resultado = cmd.ExecuteNonQuery();
                    mensaje = $"Se registró {resultado} herramienta.";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }


        public string Delete(int id)
        {
            string mensaje = "";
            var sp = "usp_EliminarHerramienta_AquiseOscar";

            using (SqlConnection cone = new SqlConnection(cadena))
            {
                cone.Open();
                SqlCommand cmd = new SqlCommand(sp, cone)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idHer", id);

                var resultado = cmd.ExecuteNonQuery();
                mensaje = $"Se ha eliminado {resultado} herramienta(s).";
            }

            return mensaje;
        }

        public Herramienta Find(int id)
        {
            var listado = GetAll();

            return listado.FirstOrDefault(x => x.IdHer == id);
        }

        public IEnumerable<Herramienta> GetAll()
        {
            var listado = new List<Herramienta>();

            var sp = "usp_ListarHerramienta_AquiseOscar";

            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Herramienta herramienta = new Herramienta()
                        {
                            IdHer = Convert.ToInt32(dr["idHer"]),
                            DesHer = Convert.ToString(dr["desHer"]),
                            MedHer = Convert.ToString(dr["medHer"]),
                            IdCategoria = Convert.ToInt32(dr["idcategoria"]),
                            PreUni = Convert.ToDecimal(dr["preUni"]),
                            Stock = Convert.ToInt32(dr["stock"])
                        };
                        listado.Add(herramienta);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }

        public IEnumerable<Herramienta> GetAllHerramientasCategoria(int idCategoria)
        {
            List<Herramienta> herramientas = new List<Herramienta>();

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_ListarHerramienta_AquiseOscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idHerramienta = reader.GetInt32(0);
                    string descripcion = reader.GetString(1);
                    string medida = reader.GetString(2);
                    int idCategoriaBD = reader.GetInt32(3);
                    string nombreCategoria = reader.GetString(4);
                    decimal precioUnitario = reader.GetDecimal(5);
                    int stock = reader.GetInt32(6);

                    if (idCategoriaBD == idCategoria)
                    {
                        Herramienta herramienta = new Herramienta()
                        {
                            IdHer= idHerramienta,
                            DesHer = descripcion,
                            MedHer = medida,
                            IdCategoria = idCategoriaBD,
                            NombreCategoria = nombreCategoria,
                            PreUni = precioUnitario,
                            Stock = stock
                        };

                        herramientas.Add(herramienta);
                    }
                }

                reader.Close();
            }

            return herramientas;
        }


        public string Update(Herramienta herramienta)
        {
            string mensaje = "";
            var sp = "usp_ActualizarHerramienta_AquiseOscar";

            try
            {
                using (SqlConnection cone = new SqlConnection(cadena))
                {
                    cone.Open();
                    SqlCommand cmd = new SqlCommand(sp, cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@idHer", herramienta.IdHer);
                    cmd.Parameters.AddWithValue("@desHer", herramienta.DesHer);
                    cmd.Parameters.AddWithValue("@medHer", herramienta.MedHer);
                    cmd.Parameters.AddWithValue("@idcategoria", herramienta.IdCategoria);
                    cmd.Parameters.AddWithValue("@preUni", herramienta.PreUni);
                    cmd.Parameters.AddWithValue("@stock", herramienta.Stock);

                    var resultado = cmd.ExecuteNonQuery();
                    mensaje = $"Se actualizó {resultado} herramienta.";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
    }
}
    

