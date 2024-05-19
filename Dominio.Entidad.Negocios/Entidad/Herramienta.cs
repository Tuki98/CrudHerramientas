using System.ComponentModel.DataAnnotations;
using System;

namespace Dominio.Entidad.Negocios.Entidad
{
    public class Herramienta
    {
        [Display(Name = "ID Herramienta")]
        public int IdHer { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo descripción es requerido")]
        public string DesHer { get; set; }

        [Display(Name = "Medida")]
        public string MedHer { get; set; }

        [Display(Name = "ID Categoría")]
        [Required(ErrorMessage = "El campo ID categoría es requerido")]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre Categoría")]
        public string NombreCategoria { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "El campo precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        public decimal? PreUni { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El campo stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int? Stock { get; set; }
        public int IdHerramienta { get; }
        public string Descripcion { get; }
        public string Medida { get; }
        public decimal PrecioUnitario { get; }

        public Herramienta(int idHer, string desHer, string medHer, int idCategoria, string nombreCategoria, decimal? preUni, int? stock)
        {
            IdHer = idHer;
            DesHer = desHer;
            MedHer = medHer;
            IdCategoria = idCategoria;
            NombreCategoria = nombreCategoria;
            PreUni = preUni;
            Stock = stock;
            IdHerramienta = idHer;
            Descripcion = desHer;
            Medida = medHer;
            PrecioUnitario = preUni ?? 0;
        }


        public Herramienta()
        {
        }
    }
}
