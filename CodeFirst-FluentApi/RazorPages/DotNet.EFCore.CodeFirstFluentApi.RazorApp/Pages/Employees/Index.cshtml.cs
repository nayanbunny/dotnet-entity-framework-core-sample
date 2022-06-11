using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public IndexModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.Department).ToListAsync();
            }
        }
    }
}
