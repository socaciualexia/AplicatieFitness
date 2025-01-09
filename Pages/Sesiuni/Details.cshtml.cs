using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Sesiuni
{
    public class DetailsModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public DetailsModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        public Sesiune Sesiune { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune.FirstOrDefaultAsync(m => m.SesiuneId == id);
            if (sesiune == null)
            {
                return NotFound();
            }
            else
            {
                Sesiune = sesiune;
            }
            return Page();
        }
    }
}
