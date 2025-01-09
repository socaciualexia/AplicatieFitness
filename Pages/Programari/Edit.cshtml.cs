using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Programari
{
    public class EditModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public EditModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        public SelectList Membri { get; set; }
        public SelectList Sesiuni { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare = await _context.Programare
                .Include(p => p.Membru)
                .Include(p => p.Sesiune)
                .FirstOrDefaultAsync(p => p.ProgramareId == id);

            if (Programare == null)
            {
                return NotFound();
            }

            Membri = new SelectList(_context.Membru, "MembruId", "Nume", Programare.MembruId);
            Sesiuni = new SelectList(_context.Sesiune, "SesiuneId", "Tip", Programare.SesiuneId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Membri = new SelectList(_context.Membru, "MembruId", "Nume", Programare.MembruId);
                Sesiuni = new SelectList(_context.Sesiune, "SesiuneId", "Tip", Programare.SesiuneId);
                return Page();
            }

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ProgramareId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgramareExists(int id)
        {
            return _context.Programare.Any(e => e.ProgramareId == id);
        }
    }
}
