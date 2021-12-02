﻿using System;
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





        //RELACION DE UNO A MUCHOS  CON VEHICLE (ESTE ES EL LADO UNO)
        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }
        //CONTANDO CUANTAS FOTOS TIENE VEHICLEPHOTOS/ RECORDAR QUE VehiclePhotos es la propiedad ICollection<VehiclePhotos> que esta aqui arribita de esta linea osea la propiedad navigacional
        [Display(Name ="Foto")]
        public int VehiclePhotosCount => VehiclePhotos == null ? 0 : VehiclePhotos.Count;

        //TODO: FIX THE CORRECT PATH
        [Display(Name = "Foto")]
        public string ImageFullPath => VehiclePhotos == null || VehiclePhotos.Count == 0
            ? $"https://localhost:44332/images/noimage.png"
            : VehiclePhotos.FirstOrDefault().ImageFullPath;


        //RELACION DE VEHICLE CON HISTORY Es decir el numnero de historias que tiene ese vehiculo
        public ICollection<History> Histories { get; set; }

        [Display(Name ="# de Historias")]
        public int HistoriesCount => Histories == null ? 0 : Histories.Count;

    }
}
