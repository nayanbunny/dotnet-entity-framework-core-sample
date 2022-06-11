using DotNet.EFCore.DatabaseFirst.RazorApp.Data;
using DotNet.EFCore.DatabaseFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.RazorApp.Pages.EmployeeSkills
{
    public class EditModel : PageModel
    {
        private readonly EFCoreDBFirstDatabaseContext _context;

        public EditModel(EFCoreDBFirstDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeSkill EmployeeSkill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }

            var employeeskill =  await _context.EmployeeSkills.FirstOrDefaultAsync(m => m.Id == id);
            if (employeeskill == null)
            {
                return NotFound();
            }
            EmployeeSkill = employeeskill;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmployeeSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSkillExists(EmployeeSkill.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeSkillExists(Guid id)
        {
          return (_context.EmployeeSkills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
