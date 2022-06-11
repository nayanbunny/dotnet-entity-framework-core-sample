using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public DetailsModel(EFCoreCodeFirstDatabaseContext context)
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
