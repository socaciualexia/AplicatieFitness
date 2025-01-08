using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Antrenori
{
    public class DeleteModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public DeleteModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Antrenor Antrenor { get; set; } = default!;

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
            else
            {
                Antrenor = antrenor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenor.FindAsync(id);
            if (antrenor != null)
            {
                Antrenor = antrenor;
                _context.Antrenor.Remove(Antrenor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
