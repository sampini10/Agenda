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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };

            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)//Verifica si estan todos los datos necesarios
            {
                var ContactoDesdeDb = await _contexto.Contacto.FindAsync(ContactoVM.Contacto.Id); //Busca el contacto en la base de datos
                ContactoDesdeDb.Nombre = ContactoVM.Contacto.Nombre;
                ContactoDesdeDb.Email = ContactoVM.Contacto.Email;
                ContactoDesdeDb.Telefono = ContactoVM.Contacto.Telefono;
                ContactoDesdeDb.CategoriaId = ContactoVM.Contacto.CategoriaId;
                ContactoDesdeDb.FechaCreacion = ContactoVM.Contacto.FechaCreacion;
                
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
