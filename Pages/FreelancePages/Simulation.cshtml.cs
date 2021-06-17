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
        private bool newSimulation = false;

        public SimulationModel(ProjetFinal_MAUREL_CHEVILLARD.Data.ProjetFinal_MAUREL_CHEVILLARDContext context)
        {
            _context = context;
            newSimulation = false;
        }

        public async Task<IActionResult> OnGetAsync(long? id, bool newSimulation = false)
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
            this.newSimulation = newSimulation;
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
            ViewData["turnover"] = Math.Round(turnover, 2);
            ViewData["turnoverPerMonth"] = Math.Round(turnover / Freelance.MonthDuration, 2);
            ViewData["workedDays"] = workedDays;
            ViewData["duration"] = Freelance.MonthDuration;
            ViewData["charges"] = Math.Round(charges, 2);
            ViewData["expenses"] = Math.Round(expenses, 2);
            ViewData["incentive"] = Math.Round(incentive, 2);
            ViewData["chargedGrossSalary"] = Math.Round(chargedGrossSalary, 2);
            ViewData["employerContributions"] = Math.Round(employerContributions, 2);
            ViewData["grossSalaryGenerated"] = Math.Round(grossSalaryGenerated, 2);
            ViewData["grossSalaryGeneratedPerMonth"] = Math.Round(grossSalaryGenerated / Freelance.MonthDuration, 2);
            ViewData["employeContributions"] = Math.Round(employeContributions, 2);
            ViewData["netSalary"] = Math.Round(netSalary, 2);
            ViewData["netSalaryAndExpense"] = Math.Round(netSalaryAndExpense, 2);
            if (newSimulation)
            {
                SendMail();
            }
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
                var body = "Retrouvez votre simulation sur la page " + @Url.PageLink("./Simulation", null, new { id = Freelance.Id });
                var message = new MailMessage
                {
                    Body = body,
                    Subject = "Simulation du " + Freelance.SimulationDate.Day + "/" + Freelance.SimulationDate.Month + "/" + Freelance.SimulationDate.Year,
                    From = new MailAddress("nicolas.chevillard@igs-campus-toulouse.fr")
                };
                message.IsBodyHtml = true;  
                message.To.Add(Freelance.Email);
                await smtp.SendMailAsync(message);
            }
        }
    }
}
