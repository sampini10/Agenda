using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        public void OnGet()
        {

        }
        public async Task<ActionResult> OnPost()
        {
            if(ModelState.IsValid)//Verifica si estan todos los datos necesarios
            {
                await _contexto.Categoria.AddAsync(Categoria);
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
