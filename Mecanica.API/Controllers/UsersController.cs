using Mecanica.API.Data;
using Mecanica.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mecanica.API.Controllers
{

    [Authorize(Roles ="Admin")]
    public class UsersController:Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        { //EN ESTE INDEX USO LA RESLACIONES QUE TENGO CON LAS DEMAS TABLAS CON EL INCLUDE GRACIAS A LA SPROPIEDADES NAVIGACIONALES
            return View(await _context.Users
                .Include(x=>x.DocumentType)
                .Include(x=>x.Vehicles)
                .Where(x=>x.UserType==UserType.User)
                .ToListAsync());
        }
    }
}
