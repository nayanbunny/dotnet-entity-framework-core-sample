using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.Skills
{
    public class DeleteModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public DeleteModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }
            var skill = await _context.Skills.FindAsync(id);

            if (skill != null)
            {
                Skill = skill;
                _context.Skills.Remove(Skill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
