using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetFinal_MAUREL_CHEVILLARD.Data;
using ProjetFinal_MAUREL_CHEVILLARD.Models;

namespace ProjetFinal_MAUREL_CHEVILLARD.Pages.FreelancePages
{
    public class ContactModel : PageModel
    {
        private readonly ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext _context;

        public ContactModel(ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            else
            {
                if (!Freelance.ConfidentialityPoliticAccepted)
                    ModelState.AddModelError("", "Veuillez accepter la politique de confidentialité");
                if (!Freelance.MarketingOfferAccepted)
                    ModelState.AddModelError("", "Veuillez accepter l'envoie de l'offre");
                if (!Freelance.ConfidentialityPoliticAccepted | !Freelance.MarketingOfferAccepted)
                    return Page();
            }
            if (TempData["Freelance"] != null)
            {
                //Fusion the temp object and the submit object
                string freelance_json = TempData["Freelance"] as string;
                this.Freelance = JsonSerializer.Deserialize<Freelance>(freelance_json).Fusion(this.Freelance,
                    new string[] { "Civility", "Lastname", "Firstname", "Email", "Telephone", "ConfidentialityPoliticAccepted", "MarketingOfferAccepted" });
            }
            //Save the new temp object
            TempData["Freelance"] = JsonSerializer.Serialize(this.Freelance);

            _context.Freelance.Add(Freelance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
