using System.Collections.Generic;

namespace DonationCore.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCollectingDonations { get; private set; } = true;

        IEnumerable<Donation> Donations { get; set; }

        public void CloseDonations() => IsCollectingDonations = false;
    }
}