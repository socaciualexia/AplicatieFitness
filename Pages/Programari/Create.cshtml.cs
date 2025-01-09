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

        [BindProperty]
        public Programare Programare { get; set; }

        public IActionResult OnGet()
        {
            ViewData["MembruID"] = new SelectList(_context.Membru, "MembruId", "Nume");
            ViewData["SesiuneID"] = new SelectList(_context.Sesiune, "SesiuneId", "Tip");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MembruID"] = new SelectList(_context.Membru, "MembruId", "Nume");
                ViewData["SesiuneID"] = new SelectList(_context.Sesiune, "SesiuneId", "Tip");
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
