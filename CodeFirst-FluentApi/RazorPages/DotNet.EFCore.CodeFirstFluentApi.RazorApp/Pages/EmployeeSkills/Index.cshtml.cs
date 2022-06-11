using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.EmployeeSkills
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public IndexModel(EFCoreCodeFirstDatabaseContext context)
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
