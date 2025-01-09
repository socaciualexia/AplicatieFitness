using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public CreateModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        public SelectList Membri { get; set; }
        public SelectList Sesiuni { get; set; }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        public IActionResult OnGet()
        {
            Membri = new SelectList(_context.Membru, "MembruId", "Nume");
            Sesiuni = new SelectList(_context.Sesiune, "SesiuneId", "Tip");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Membri = new SelectList(_context.Membru, "MembruId", "Nume");
                Sesiuni = new SelectList(_context.Sesiune, "SesiuneId", "Tip");
                return Page();
            }

            var membruExists = await _context.Membru.FindAsync(Programare.MembruId);
            var sesiuneExists = await _context.Sesiune.FindAsync(Programare.SesiuneId);

            if (membruExists == null || sesiuneExists == null)
            {
                ModelState.AddModelError("", "Membru sau sesiune invalide.");
                Membri = new SelectList(_context.Membru, "MembruId", "Nume");
                Sesiuni = new SelectList(_context.Sesiune, "SesiuneId", "Tip");
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
