using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;  
        }

        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = new Modelos.Contacto()
            };

            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)//Verifica si estan todos los datos necesarios
            {
                await _contexto.Contacto.AddAsync(ContactoVM.Contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");//si guarda redirecciona a la pagina
            }
            else
            {
                return Page();//si algo sale mal, sigue en la misma pagina
            }
        }
    }
}
