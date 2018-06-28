using System;
using System.Collections.Generic;
using DonationCore.Entities;
using DonationCore.Gateways;

namespace DonationCore.UseCases
{
    public class GetProjects
    {
        private IGatewayGetProjects _getProjects;

        public GetProjects(IGatewayGetProjects gatewayGetProjects)
        {
            _getProjects = gatewayGetProjects;
        }

        public IEnumerable<Project> GetAllProjects() => _getProjects.GetProjects();

        public Project GetProject(long id) => _getProjects.GetProject(id);
    }
}