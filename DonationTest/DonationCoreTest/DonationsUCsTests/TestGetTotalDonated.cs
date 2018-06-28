using System.Collections.Generic;
using System.Linq;
using DonationCore.Entities;
using DonationCore.Gateways;
using DonationCore.UseCases;
using NSubstitute;
using Xunit;

namespace DonationTest.DonationCoreTest.DonationsUCsTests
{
    public class TestGetTotalDonated
    {
        IGatewayGetTotalDonated _mockOfGetTotalDonated;
        GetTotalDonated _getTotalDonated;
        GetProjects _getProjects;
        IGatewayGetProjects _mockOfProjects;
        IEnumerable<Project> _projects;

        public TestGetTotalDonated()
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
                    Name = "Project 2",
                    Donations = new List<Donation>()
                    {
                        new Donation 
                        {
                            Amount = 100
                        }
                    }
                }
            };

            _mockOfProjects = Substitute.For<IGatewayGetProjects>();
            _mockOfProjects.GetProjects().Returns(_projects);
            _mockOfProjects.GetProject(1).Returns(_projects.Single(p => p.Id == 1));
            _mockOfProjects.GetProject(2).Returns(_projects.Single(p => p.Id == 2));
            
            _mockOfGetTotalDonated = Substitute.For<IGatewayGetTotalDonated>();

            _getProjects = new GetProjects(_mockOfProjects);
            _getTotalDonated = new GetTotalDonated(_mockOfGetTotalDonated);              
        }
        
        [Fact]
        public void TestGetTotalDonatedForAProjectThatHasNotReceivedDonationsYet() 
        {
            var project = _getProjects.GetProject(1);

            var totalDonated = _getTotalDonated.GetTotalDonatedForAProject(project);

            Assert.Equal(totalDonated, 0);
        
        }
        [Fact]
        public void TestGetTotalDonatedForAProjectThatHasAlreadyReceivedDonations() 
        {
            var project = _getProjects.GetProject(2);

            var totalDonated = _getTotalDonated.GetTotalDonatedForAProject(project);

            Assert.Equal(totalDonated, 100);
        }
    }
}