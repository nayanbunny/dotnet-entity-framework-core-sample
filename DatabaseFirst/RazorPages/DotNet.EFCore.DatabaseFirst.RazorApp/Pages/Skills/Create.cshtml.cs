using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.Skills
{
    public class CreateModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public CreateModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Skill Skill { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Skills == null || Skill == null)
            {
                return Page();
            }

            _context.Skills.Add(Skill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
