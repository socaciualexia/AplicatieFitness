﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly AplicatieFitness.Data.AplicatieFitnessContext _context;

        public DeleteModel(AplicatieFitness.Data.AplicatieFitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abonament Abonament { get; set; } = default!;

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
            else
            {
                Abonament = abonament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonament.FindAsync(id);
            if (abonament != null)
            {
                Abonament = abonament;
                _context.Abonament.Remove(Abonament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
