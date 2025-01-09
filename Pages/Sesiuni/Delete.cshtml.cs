using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Sesiuni
{
    public class DeleteModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public DeleteModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sesiune Sesiune { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune.FirstOrDefaultAsync(m => m.SesiuneId == id);

            if (sesiune == null)
            {
                return NotFound();
            }
            else
            {
                Sesiune = sesiune;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune.FindAsync(id);
            if (sesiune != null)
            {
                Sesiune = sesiune;
                _context.Sesiune.Remove(Sesiune);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
