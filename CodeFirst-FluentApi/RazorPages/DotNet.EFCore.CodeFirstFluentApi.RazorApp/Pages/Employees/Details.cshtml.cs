using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public DetailsModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
