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

namespace AplicatieFitness.Pages.Abonamente
{
    public class EditModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public EditModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abonament Abonament { get; set; } = default!;

        public SelectList TipuriAbonament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonament.FirstOrDefaultAsync(m => m.AbonamentId == id);
            if (abonament == null)
            {
                return NotFound();
            }

            Abonament = abonament;
            TipuriAbonament = new SelectList(new List<string>
            {
                "Abonament Full-Time",
                "Abonament cu 8 intrări",
                "One Day Happy Day",
                "Abonament Studenți"
            });

            return Page();
        }

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

            _context.Attach(Abonament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonamentExists(Abonament.AbonamentId))
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

        private bool AbonamentExists(int id)
        {
            return _context.Abonament.Any(e => e.AbonamentId == id);
        }
    }
}
