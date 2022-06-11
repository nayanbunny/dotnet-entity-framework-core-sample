using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data;
using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public CreateModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Employees == null || Employee == null)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
