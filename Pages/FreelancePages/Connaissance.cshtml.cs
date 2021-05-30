using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_MAUREL_CHEVILLARD.Models;

namespace ProjetFinal_MAUREL_CHEVILLARD.Pages.FreelancePages
{
    public class ConnaissanceModel : PageModel
    {
        private readonly ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext _context;

        public ConnaissanceModel(ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Freelance Freelance { get; set; }
    }
}
