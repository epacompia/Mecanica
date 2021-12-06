using Mecanica.API.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        //IMPLEMENTACION DE UN COMBO BOX DE UN MODELO LLAMADO BRAND ES SIMILAR PARA TODOS
        public  IEnumerable<SelectListItem> GetCombosBrands()
        {
            List<SelectListItem> list = _context.Brands.Select(x=>new SelectListItem 
            {Text=x.Descripcion,
             Value= $"{x.Id}"   //ESTA ES OTRA FORMA DE CONVERTIR A STRING
             }) 
                .OrderBy(X=>X.Text)
                .ToList();

            
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"

            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosDocumentsTypes()
        {
            List<SelectListItem> list = _context.DocumentTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"   //ESTA ES OTRA FORMA DE CONVERTIR A STRING
            })
                .OrderBy(X => X.Text)
                .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"

            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosProcedures()
        {
            List<SelectListItem> list = _context.Procedures.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"   //ESTA ES OTRA FORMA DE CONVERTIR A STRING
            })
                .OrderBy(X => X.Text)
                .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un procedimiento...]",
                Value = "0"

            });

            return list;
        }

        public IEnumerable<SelectListItem> GetCombosVehicleTypes()
        {
            List<SelectListItem> list = _context.VehicleTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"   //ESTA ES OTRA FORMA DE CONVERTIR A STRING
            })
                .OrderBy(X => X.Text)
                .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una tipo de vehiculo...]",
                Value = "0"

            });

            return list;
        }
    }
}
