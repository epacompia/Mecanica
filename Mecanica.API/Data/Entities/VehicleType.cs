using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Display(Name ="Tipo de Vehiculo")]
        [MaxLength(50,ErrorMessage ="El campo {0} no puede exceder mas de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Description { get; set; }

        //RELACION DE UNO A MUCHOS CON VEHICLE (LADO UNO)
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
