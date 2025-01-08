using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Antrenori
{
    public class EditModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public EditModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Antrenor Antrenor { get; set; } = default!;

        public SelectList SpecializariOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenor.FirstOrDefaultAsync(m => m.AntrenorId == id);
            if (antrenor == null)
            {
                return NotFound();
            }

            Antrenor = antrenor;

            SpecializariOptions = new SelectList(new List<string> { "Yoga", "Fitness", "Powerlifting" });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                SpecializariOptions = new SelectList(new List<string> { "Yoga", "Fitness", "Powerlifting" });
                return Page();
            }

            _context.Attach(Antrenor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrenorExists(Antrenor.AntrenorId))
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

        private bool AntrenorExists(int id)
        {
            return _context.Antrenor.Any(e => e.AntrenorId == id);
        }
    }
}
