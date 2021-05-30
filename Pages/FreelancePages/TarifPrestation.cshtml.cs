using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_MAUREL_CHEVILLARD.Models;

namespace ProjetFinal_MAUREL_CHEVILLARD.Pages
{
    public class TarifPrestationModel : PageModel
    {

        private readonly ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext _context;

        public TarifPrestationModel(ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Page();
        }

        [BindProperty(SupportsGet= true)]
        public Freelance Freelance { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Freelance.Add(Freelance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }

    public class CreateModel : PageModel
    {
       
    }

}
