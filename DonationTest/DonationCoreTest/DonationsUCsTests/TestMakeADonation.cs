using Xunit;
using NSubstitute;
using System.Collections.Generic;
using DonationCore.UseCases;
using DonationCore.Gateways;
using DonationCore.Entities;
using System.Linq;
using System;

namespace DonationTest.DonationCoreTest.MakeADonationTests
{
    public class TestMakeADonation 
    {
        GetProjects _getProjects;
        MakeADonation _makeADonation;
        GetTotalDonated _getTotalDonated;
        IGatewayMakeADonation _mockOfMakeADonation;
        IGatewayGetProjects _mockOfProjects;
        IGatewayGetTotalDonated _mockOfGetTotalDonated;
        IEnumerable<Project> _projects;

        public TestMakeADonation() 
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
            
            _mockOfMakeADonation = Substitute.For<IGatewayMakeADonation>();
            _mockOfGetTotalDonated = Substitute.For<IGatewayGetTotalDonated>();

            _getProjects = new GetProjects(_mockOfProjects);
            _makeADonation = new MakeADonation(_mockOfMakeADonation);
            _getTotalDonated = new GetTotalDonated(_mockOfGetTotalDonated);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(20)]
        public void TestADonation(decimal amount)
        {
            var project = _getProjects.GetProject(1); //dummy, but its ok for this context
            
            decimal totalDonatedForThisProject = _getTotalDonated.GetTotalDonatedForAProject(project);
            
            _makeADonation.CollectDonation(amount, project);
            
            Assert.Equal(project.Donations.Sum(d => d.Amount), totalDonatedForThisProject += amount);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-20)]
        public void TestAnInvalidDonation(decimal amount)
        {
            var project = _getProjects.GetProject(1); //dummy, but its ok for this context
            decimal totalDonatedForThisProject = _getTotalDonated.GetTotalDonatedForAProject(project);

            Assert.Throws<Exception>(() => _makeADonation.CollectDonation(amount, project));
        }

        [Theory]
        [InlineData(100, false)]
        [InlineData(-20, false)]
        public void TestADonationForAClosedProject(decimal amount, bool isProjectCollectingDonations)
        {
            var project = _getProjects.GetProject(1); //dummy, but its ok for this context
            
            if(!isProjectCollectingDonations) project.CloseDonations();
            
            decimal totalDonatedForThisProject = _getTotalDonated.GetTotalDonatedForAProject(project);
            
            Assert.Throws<Exception>(() => _makeADonation.CollectDonation(amount, project));
        }
    }
}