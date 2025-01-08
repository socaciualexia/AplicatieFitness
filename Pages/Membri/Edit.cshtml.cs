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

namespace AplicatieFitness.Pages.Membri
{
    public class EditModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public EditModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membru Membru { get; set; } = default!;

        public SelectList RoleOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membru = await _context.Membru.FirstOrDefaultAsync(m => m.MembruId == id);
            if (membru == null)
            {
                return NotFound();
            }
            Membru = membru;

            RoleOptions = new SelectList(new List<int> { 1, 2 });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RoleOptions = new SelectList(new List<int> { 1, 2 });
                return Page();
            }

            _context.Attach(Membru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembruExists(Membru.MembruId))
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

        private bool MembruExists(int id)
        {
            return _context.Membru.Any(e => e.MembruId == id);
        }
    }
}
