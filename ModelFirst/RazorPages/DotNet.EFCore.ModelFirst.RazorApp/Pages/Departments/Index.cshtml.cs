using DotNet.EFCore.ModelFirst.RazorApp.Data;
using DotNet.EFCore.ModelFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.ModelFirst.RazorApp.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreModelFirstDatabaseContext _context;

        public IndexModel(EFCoreModelFirstDatabaseContext context)
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
