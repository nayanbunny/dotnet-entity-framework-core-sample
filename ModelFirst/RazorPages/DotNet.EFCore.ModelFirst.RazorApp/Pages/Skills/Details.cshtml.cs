﻿using DotNet.EFCore.ModelFirst.RazorApp.Data;
using DotNet.EFCore.ModelFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.ModelFirst.RazorApp.Pages.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreModelFirstDatabaseContext _context;

        public DetailsModel(EFCoreModelFirstDatabaseContext context)
        {
            _context = context;
        }

      public Skill Skill { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            else 
            {
                Skill = skill;
            }
            return Page();
        }
    }
}
