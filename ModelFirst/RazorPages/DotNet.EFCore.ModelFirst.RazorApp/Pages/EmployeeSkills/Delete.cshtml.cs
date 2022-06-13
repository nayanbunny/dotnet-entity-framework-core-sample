using DotNet.EFCore.ModelFirst.RazorApp.Data;
using DotNet.EFCore.ModelFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.ModelFirst.RazorApp.Pages.EmployeeSkills
{
    public class DeleteModel : PageModel
    {
        private readonly EFCoreModelFirstDatabaseContext _context;

        public DeleteModel(EFCoreModelFirstDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EmployeeSkill EmployeeSkill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }

            var employeeskill = await _context.EmployeeSkills.FirstOrDefaultAsync(m => m.Id == id);

            if (employeeskill == null)
            {
                return NotFound();
            }
            else 
            {
                EmployeeSkill = employeeskill;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }
            var employeeskill = await _context.EmployeeSkills.FindAsync(id);

            if (employeeskill != null)
            {
                EmployeeSkill = employeeskill;
                _context.EmployeeSkills.Remove(EmployeeSkill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
