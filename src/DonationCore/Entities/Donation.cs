namespace DonationCore.Entities
{
    public class Donation
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public Project Project { get; set; }
    }
}