using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidad.Negocios.Entidad
{
    public class Categoria
    {
        [Display(Name = "ID Categoría")]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre Categoría")]
        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        public string NombreCategoria { get; set; }

        public Categoria(int idCategoria, string nombreCategoria)
        {
            IdCategoria = idCategoria;
            NombreCategoria = nombreCategoria;
        }

        public Categoria()
        {
        }
    }
}
