using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Data.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Vehiculo")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        public Vehicle Vehicle { get; set; }

        //[Display(Name ="Mecanico")]
        //[Required(ErrorMessage ="El campo {0} es requerido")]
        //public User User { get; set; }

        [Display(Name ="Fecha")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Display(Name ="Kilometraje")]
        [DisplayFormat(DataFormatString ="0:N0")]
        public int Mileage { get; set; }

        [Display(Name ="Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }



        //RELACION CON DETAIL PROPIEDAD NAVIGACIONAL ( LADO UNO) y propiedades de calculo
        public ICollection<Detail> Details { get; set; }

        [Display(Name ="# de detalles")]
        public int DetailsCount => Details == null ? 0 : Details.Count;

        [Display(Name ="Total mano de obra")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal TotalLabor => Details == null ? 0 : Details.Sum(x=>x.LaborPrice);

        [Display(Name = "Total repuestos")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalSpareParts => Details == null ? 0 : Details.Sum(x=>x.SparePartsPrice);

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total => Details == null ? 0 : Details.Sum(x=>x.TotalPrice);
    }
}
