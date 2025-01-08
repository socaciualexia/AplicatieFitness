using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Abonamente
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public CreateModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        public SelectList TipuriAbonament { get; set; }

        public IActionResult OnGet()
        {
            TipuriAbonament = new SelectList(new List<string>
            {
                "Abonament Full-Time",
                "Abonament cu 8 intrări",
                "One Day Happy Day",
                "Abonament Studenți"
            });

            return Page();
        }

        [BindProperty]
        public Abonament Abonament { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TipuriAbonament = new SelectList(new List<string>
                {
                    "Abonament Full-Time",
                    "Abonament cu 8 intrări",
                    "One Day Happy Day",
                    "Abonament Studenți"
                });

                return Page();
            }

            _context.Abonament.Add(Abonament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
