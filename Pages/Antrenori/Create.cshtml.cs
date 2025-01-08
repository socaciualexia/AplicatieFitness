using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Antrenori
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public CreateModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        public SelectList SpecializariOptions { get; set; }

        public IActionResult OnGet()
        {
            SpecializariOptions = new SelectList(new List<string> { "Yoga", "Fitness", "Powerlifting" });
            return Page();
        }

        [BindProperty]
        public Antrenor Antrenor { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                SpecializariOptions = new SelectList(new List<string> { "Yoga", "Fitness", "Powerlifting" });
                return Page();
            }

            _context.Antrenor.Add(Antrenor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
