using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace flo.desarrollo.prueba.entidades.Fabricante
{
    public class Fabricante
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
