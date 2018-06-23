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

        public IEnumerable<Project> GetAllProjects() 
        {
            return _getProjects.GetProjects();
        }
    }
}