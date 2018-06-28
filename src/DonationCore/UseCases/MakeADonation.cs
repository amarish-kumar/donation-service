using System;
using System.Collections.Generic;
using DonationCore.Entities;
using DonationCore.Gateways;

namespace DonationCore.UseCases
{
    public class MakeADonation
    {
        private IGatewayMakeADonation _makeADonation;

        public MakeADonation(IGatewayMakeADonation makeADonation)
        {
            _makeADonation = makeADonation;
        }

        public void CollectDonation(decimal amountDonated, Project project) 
        {
            if(amountDonated <= 0)
                throw new Exception("The amount donated must be greater than 0."); //business exception
            
            if(!project.IsCollectingDonations)
                throw new Exception("This project is not collecting donations anymore."); //another business expcetion

            Donation donation = new Donation 
            {
                Amount = Math.Round(amountDonated, 2),
                Project = project
            };

            project.CollectDonation(donation);

            _makeADonation.PersistDonation(donation);
        }
    }
}