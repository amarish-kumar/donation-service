using DonationCore.Gateways;

namespace DonationCore.UseCases
{
    public class MakeADonation
    {
        private IMakeADonation _makeADonation;

        public MakeADonation(IMakeADonation makeADonation)
        {
            _makeADonation = makeADonation;
        }

        public void AddDonation(decimal amountDonated) => _makeADonation.AddDonation(amountDonated);
    }
}