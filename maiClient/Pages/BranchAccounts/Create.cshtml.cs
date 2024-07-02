using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace maiClient.Pages.BranchAccounts
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.SilverJewelry2024DBContext _context;

        public CreateModel(BusinessObject.Models.SilverJewelry2024DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BranchAccount BranchAccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BranchAccounts == null || BranchAccount == null)
            {
                return Page();
            }

            _context.BranchAccounts.Add(BranchAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
