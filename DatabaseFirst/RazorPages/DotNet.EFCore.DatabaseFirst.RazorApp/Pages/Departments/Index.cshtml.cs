using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public IndexModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments.ToListAsync();
            }
        }
    }
}
