using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class Procedure
    {
        public int Id { get; set; }

        [Display(Name = "Procedimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede exceder mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Price { get; set; }


        //RELACION CON DETAIL PROPIEDAD NAVIGACIONAL ( LADO UNO) y propiedades de calculo
        public ICollection<Detail> Details { get; set; }

    }
}
