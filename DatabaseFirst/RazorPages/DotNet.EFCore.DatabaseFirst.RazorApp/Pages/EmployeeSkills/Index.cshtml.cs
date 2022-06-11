using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.EmployeeSkills
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public IndexModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

        public IList<EmployeeSkill> EmployeeSkill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EmployeeSkills != null)
            {
                EmployeeSkill = await _context.EmployeeSkills
                .Include(e => e.Employee)
                .Include(e => e.Skill).ToListAsync();
            }
        }
    }
}
