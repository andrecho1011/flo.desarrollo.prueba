using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace flo.desarrollo.prueba.entidades.Articulo
{
    public class Articulo
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage ="Se necesita un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Se necesita un precio")]
        public int Precio { get; set; }
        
        public virtual ICollection<Fabricante.Fabricante> Fabricante { get; set; }
    }
}
