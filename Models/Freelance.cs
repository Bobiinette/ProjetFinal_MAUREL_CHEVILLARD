using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetFinal_MAUREL_CHEVILLARD.Models
{
    public class Freelance
    {
        [Key]
        public long Id { get; set; }
        public String ResidenceCountry { get; set; }
        public String WorkCountry { get; set; }

        public int DayPrice { get; set; }

        public int HourPrice { get; set; }

        public int MonthPrice { get; set; }

        public int TurnOver { get; set; }

        public bool NotKnowPrice { get; set; }

        public int NetSalary { get; set; }

        public int BrutSalary { get; set; }

        public int MonthDuration { get; set; }

        public int DayByMonthDuration { get; set; }

        public bool LessOneMonthDuration { get; set; }

        public String Civility { get; set; }

        public String Lastname { get; set; }

        public String Firstname { get; set; }

        public String Email { get; set; }

        public String Telephone { get; set; }

        public bool ConfidentialityPoliticAccepted { get; set; }

        public bool MarketingOfferAccepted { get; set; }

        public DateTime SimulationDate { get; set; }


        public Freelance()
        {

        }

        public Freelance Fusion(Freelance f, String[] properties)
        {
            //Foreach on the attributes of f to copy paste the value of all non null properties in this
            foreach (String property in properties)
            {
                var attr = f.GetType().GetProperty(property).GetValue(f);
                if (attr != null)
                {
                    this.GetType().GetProperty(property).SetValue(this, attr);
                }
            }
            return this;
        }
    }
}