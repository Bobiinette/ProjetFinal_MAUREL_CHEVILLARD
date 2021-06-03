using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            TempData["Freelance"] = null;
            return Page();
        }

        [BindProperty]
        public Freelance Freelance { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine(TempData["Freelance"]);
            if (TempData["Freelance"] != null)
            {
                //Fusion the temp object and the submit object
                string freelance_json = TempData["Freelance"] as string;
                this.Freelance = JsonSerializer.Deserialize<Freelance>(freelance_json).Fusion(this.Freelance,
                    new string[] { "ResidenceCountry", "WorkCountry" });
            }
            //Save the new temp object
            TempData["Freelance"] = JsonSerializer.Serialize(this.Freelance);

            return RedirectToPage("./TarifPrestation");
        }
    }
}
