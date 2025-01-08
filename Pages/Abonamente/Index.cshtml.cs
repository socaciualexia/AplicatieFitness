using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Abonamente
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public IndexModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        public IList<Abonament> Abonament { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Abonament = await _context.Abonament.ToListAsync();
        }
    }
}
