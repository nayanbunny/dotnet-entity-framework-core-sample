using DotNet.EFCore.ModelFirst.RazorApp.Data;
using DotNet.EFCore.ModelFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.ModelFirst.RazorApp.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreModelFirstDatabaseContext _context;

        public DetailsModel(EFCoreModelFirstDatabaseContext context)
        {
            _context = context;
        }

      public Department Department { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }
    }
}
