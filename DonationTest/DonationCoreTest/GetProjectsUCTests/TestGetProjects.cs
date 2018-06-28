using Xunit;
using NSubstitute;
using System.Collections.Generic;
using DonationCore.UseCases;
using DonationCore.Gateways;
using DonationCore.Entities;
using System.Linq;

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
                },
                new Project 
                {
                    Id = 2,
                    Name = "Project 2"
                }
            };
            
            _mockOfProjects = Substitute.For<IGatewayGetProjects>();
            _mockOfProjects.GetProjects().Returns(_projects);
            _mockOfProjects.GetProject(1).Returns(_projects.Single(p => p.Id == 1));
            _mockOfProjects.GetProject(2).Returns(_projects.Single(p => p.Id == 2));
            
            _getProjects = new GetProjects(_mockOfProjects);
        }

        [Fact]
        public void TestGetAllProjects()
        {
            var projects = _getProjects.GetAllProjects();

            Assert.Equal(projects, _projects);
        }

        [Fact]
        public void TestDisableProjectToGetDonations() 
        {
            var project = _getProjects.GetAllProjects().FirstOrDefault();
            project.CloseDonations();

            Assert.False(project.IsCollectingDonations);            
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestGetAProjectById(long id) 
        {
            var project = _getProjects.GetProject(id);

            Assert.NotNull(project);
            Assert.Equal(project.Id, id);
        }
    }
}