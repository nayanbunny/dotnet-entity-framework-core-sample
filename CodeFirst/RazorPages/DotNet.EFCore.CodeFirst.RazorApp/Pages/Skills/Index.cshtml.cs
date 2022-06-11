using DotNet.EFCore.CodeFirst.RazorApp.Data;
using DotNet.EFCore.CodeFirst.RazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirst.RazorApp.Pages.Skills
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreCodeFirstDatabaseContext _context;

        public IndexModel(EFCoreCodeFirstDatabaseContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Skills != null)
            {
                Skill = await _context.Skills.ToListAsync();
            }
        }
    }
}
