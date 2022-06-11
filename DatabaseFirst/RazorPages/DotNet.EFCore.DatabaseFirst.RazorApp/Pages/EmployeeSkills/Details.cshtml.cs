using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.EmployeeSkills
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public DetailsModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

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
    }
}
