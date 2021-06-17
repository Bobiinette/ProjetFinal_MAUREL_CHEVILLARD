using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_MAUREL_CHEVILLARD.Data;
using ProjetFinal_MAUREL_CHEVILLARD.Models;

namespace ProjetFinal_MAUREL_CHEVILLARD.Pages.FreelancePages
{
    public class SimulationModel : PageModel
    {
        private readonly ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext _context;

        public SimulationModel(ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Freelance = await _context.Freelance.FirstOrDefaultAsync(m => m.Id == id);

            if (Freelance == null)
            {
                return NotFound();
            }
            double turnover;
            int workedDays = Freelance.MonthDuration * Freelance.DayByMonthDuration;
            if (Freelance.DayPrice > 0)
            {
                turnover = workedDays * Freelance.DayPrice;
            }
            else if (Freelance.HourPrice > 0)
            {
                turnover = workedDays * Freelance.HourPrice * 7;
            }
            else if (Freelance.MonthPrice > 0)
            {
                turnover = Freelance.MonthDuration * Freelance.MonthPrice;
            }
            else
            {
                turnover = 0;
            }
            double charges = 0.05 * turnover;
            double expenses = 0.05 * turnover;
            double incentive = 0.1 * turnover;
            double chargedGrossSalary = turnover - charges - expenses - incentive;
            double employerContributions = chargedGrossSalary * 0.341;
            double grossSalaryGenerated = turnover - employerContributions;
            double employeContributions = chargedGrossSalary * 0.793;
            double netSalary = (incentive * 0.903) + (grossSalaryGenerated * 0.824);
            double netSalaryAndExpense = netSalary + expenses;
            //Put the datas in the view data
            ViewData["turnover"] = turnover;
            ViewData["turnoverPerMonth"] = turnover / Freelance.MonthDuration;
            ViewData["workedDays"] = workedDays;
            ViewData["duration"] = Freelance.MonthDuration;
            ViewData["charges"] = charges;
            ViewData["expenses"] = expenses;
            ViewData["incentive"] = incentive;
            ViewData["chargedGrossSalary"] = chargedGrossSalary;
            ViewData["employerContributions"] = employerContributions;
            ViewData["grossSalaryGenerated"] = grossSalaryGenerated;
            ViewData["grossSalaryGeneratedPerMonth"] = grossSalaryGenerated / Freelance.MonthDuration;
            ViewData["employeContributions"] = employeContributions;
            ViewData["netSalary"] = netSalary;
            ViewData["netSalaryAndExpense"] = netSalaryAndExpense;
            SendMail();
            return Page();
        }

        [BindProperty]
        public Freelance Freelance { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task SendMail()
        {
            using (var smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                //Where the mails will be send
                smtp.PickupDirectoryLocation = @"c:\maildump";
                var message = new MailMessage
                {
                    Body = "Test",
                    Subject = "Tests avec Razor",
                    From = new MailAddress("nicolas.chevillard@igs-campus-toulouse.fr")
                };
                message.IsBodyHtml = true;
                message.To.Add(Freelance.Email);
                await smtp.SendMailAsync(message);
            }
        }
    }
}
