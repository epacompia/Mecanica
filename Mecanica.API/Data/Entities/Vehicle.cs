using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name ="Tipo de Vehiculo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public VehicleType VehicleType { get; set; }

        [Display(Name ="Marca")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Brand Brand { get; set; }

        [Display(Name ="Modelo")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Range(1900,3000,ErrorMessage ="Valor de modelo no valido")]
        public int Model { get; set; }

        [Display(Name ="Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage ="Formato de placa incorrecto")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(6,MinimumLength =6,ErrorMessage ="El campo {0} debe tener {1} caracteres")]
        public string Plaque { get; set; }


        [Display(Name ="Linea")]
        [MaxLength(50,ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Line { get; set; }


        [Display(Name ="Color")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener mas de  {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Color { get; set; }

        [Display(Name ="Propietario")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public User User { get; set; }

        [Display(Name ="Observacion")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }


    }
}
