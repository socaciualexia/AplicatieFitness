using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Antrenori
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public IndexModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        public IList<Antrenor> Antrenor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Antrenor != null)
            {
                Antrenor = await _context.Antrenor.ToListAsync();
            }
        }
    }
}
