using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name ="Tipo de Marca")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(50,ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        public string Descripcion { get; set; }

        //RELACION DE UNO A MUCHOS CON VEHICLE (LADO UNO)
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
