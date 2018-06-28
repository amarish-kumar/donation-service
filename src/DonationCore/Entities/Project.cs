using System.Collections.Generic;

namespace DonationCore.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCollectingDonations { get; private set; } = true;

        public IList<Donation> Donations { get; set; }

        //Some wide business logic
        public void CloseDonations() => IsCollectingDonations = false;

        public void CollectDonation(Donation donation) 
        {
            if(Donations == null)
                Donations = new List<Donation>();
            
            Donations.Add(donation);
        }
    }
}