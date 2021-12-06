using Mecanica.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class User: IdentityUser
    {
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string LastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DocumentType DocumentType { get; set; }


        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Document { get; set; }


        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: FIX THE IMAGE PATH
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
           ? $"https://localhost:44332/images/noimage.png"
           : $"https://vehicleszuluprep.blob.core.windows.net/users/{ImageId}";

        [Display(Name ="Tipo de Usuario")]
        public UserType UserType { get; set; }

        [Display(Name ="Nombre Completo")]
        public string FullName => $"{FirstName} {LastName}";


        //RELACION DE UNO A MUCHOS CON VEHICLE (LADO UNO)
        public ICollection<Vehicle> Vehicles { get; set; }
        // AGREGO LA PROPIEDAD DE LECTURA PARA Vehicle
        [Display(Name = "# de vehiculos")]
        public int VehiclesCount => Vehicles == null ? 0 : Vehicles.Count;



        //RELACION DE VEHICLE CON HISTORY Es decir el numnero de historias que tiene ese vehiculo
        //ESTAS SON LAS HISTORIAS QUE A ATENDIDO UN DETERMINADO MECANICO
        //public ICollection<History> Histories { get; set; }




       
    }
}
