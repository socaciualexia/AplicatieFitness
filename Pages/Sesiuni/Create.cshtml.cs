using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Sesiuni
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public CreateModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        public SelectList Antrenori { get; set; }
        public SelectList Membri { get; set; }

        [BindProperty]
        public Sesiune Sesiune { get; set; } = default!;

        public IActionResult OnGet()
        {
            Antrenori = new SelectList(_context.Antrenor, "AntrenorId", "Nume");
            Membri = new SelectList(_context.Membru, "MembruId", "Nume");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Antrenori = new SelectList(_context.Antrenor, "AntrenorId", "Nume");
                Membri = new SelectList(_context.Membru, "MembruId", "Nume");

                return Page();
            }

            _context.Sesiune.Add(Sesiune);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
