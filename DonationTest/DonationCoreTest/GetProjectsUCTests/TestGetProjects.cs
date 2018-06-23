using Xunit;
using NSubstitute;
using System.Collections.Generic;
using DonationCore.UseCases;
using DonationCore.Gateways;
using DonationCore.Entities;

namespace DonationTest.DonationCoreTest.GetProjectsUCTests
{
    public class TestGetProjects
    {
        GetProjects _getProjects; 

        IGatewayGetProjects _mockOfProjects;

        IEnumerable<Project> _projects;

        public TestGetProjects()
        {
            _projects = new List<Project>() 
            {
                new Project 
                {
                    Id = 1,
                    Name = "Project 1"
                }
            };
            
            _mockOfProjects = Substitute.For<IGatewayGetProjects>();
            _mockOfProjects.GetProjects().Returns(_projects);
            
            _getProjects = new GetProjects(_mockOfProjects);
        }

        [Fact]
        public void TestGetAllProjects()
        {
            var projects = _getProjects.GetAllProjects();

            Assert.Equal(projects, _projects);
        }
    }
}