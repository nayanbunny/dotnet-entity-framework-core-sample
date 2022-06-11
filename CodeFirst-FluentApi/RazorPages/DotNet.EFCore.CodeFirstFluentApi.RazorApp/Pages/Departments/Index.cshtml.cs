using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public IndexModel(EFCoreCodeFirstDatabaseContext context)
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
