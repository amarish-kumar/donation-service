using DonationCore.Entities;

namespace DonationCore.Gateways
{
    public interface IGatewayGetTotalDonated
    {
        decimal GetTotalDonated(Project project);
    }
}