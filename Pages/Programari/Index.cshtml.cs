using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Data;
using AplicatieFitness.Models;

namespace AplicatieFitness.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieFitnessContext _context;

        public IndexModel(AplicatieFitnessContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get; set; }

        public async Task OnGetAsync()
        {
            Programare = await _context.Programare
                .Include(p => p.Membru)
                .Include(p => p.Sesiune)
                .ToListAsync();
        }
    }
}
