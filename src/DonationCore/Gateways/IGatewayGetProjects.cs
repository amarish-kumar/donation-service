using System.Collections.Generic;
using DonationCore.Entities;

namespace DonationCore.Gateways
{
    public interface IGatewayGetProjects
    {
        IEnumerable<Project> GetProjects();

        Project GetProject(long id);
    }
}