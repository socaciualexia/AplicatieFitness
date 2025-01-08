using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Membri
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public CreateModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        public SelectList RoleOptions { get; set; }

        public IActionResult OnGet()
        {
            RoleOptions = new SelectList(new List<int> { 1, 2 }); // Inițializează opțiunile pentru roluri
            return Page();
        }

        [BindProperty]
        public Membru Membru { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membru.Add(Membru);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
