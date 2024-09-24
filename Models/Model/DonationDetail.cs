using SQLite;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Model
{
    public class DonationDetail
    {
        [Required(ErrorMessage = "Donation entityName is required")]
        public string EntityName { get; set; }
        public double DonationAmount { get; set; }
        //מסוג enum
        public string EntityType { get; set; }
        public string DonationTarget { get; set; }
        public string ConditionForDonation { get; set; }
        public string CurrencyType { get; set; }
        public string ConversionRate { get; set; }





        

    }
}
