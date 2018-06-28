using System;
using System.Linq;
using DonationCore.Entities;
using DonationCore.Gateways;

namespace DonationCore.UseCases
{
    public class GetTotalDonated
    {
        private IGatewayGetTotalDonated _getTotalDonated;

        public GetTotalDonated(IGatewayGetTotalDonated getTotalDonated)
        {
            _getTotalDonated = getTotalDonated;
        }

        public decimal GetTotalDonatedForAProject(Project project) 
        {
            if(project.Donations == null) return 0;

            return Math.Round(project.Donations.Sum(d => d.Amount));
        }
    }
}