using DotNet.EFCore.ModelFirst.RazorApp.Data;
using DotNet.EFCore.ModelFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.ModelFirst.RazorApp.Pages.EmployeeSkills
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreModelFirstDatabaseContext _context;

        public IndexModel(EFCoreModelFirstDatabaseContext context)
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
