using DonationCore.Entities;

namespace DonationCore.Gateways
{
    public interface IGatewayMakeADonation
    {
        void PersistDonation(Donation donation);
    }
}