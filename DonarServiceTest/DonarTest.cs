using DonarService.Models;
using DonarService.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonarServiceTest
{
    public class Tests
    {
        //test
        List<Donar> donars;
        Mock<DonarRepository> mockdonarrepo;

        [SetUp]
        public void Setup()
        {
           donars = new List<Donar>() {

                new Donar() { DonorId=1,Amount=100,DateOfDonation=DateTime.Parse("10-10-2020"),DonorName="srinu",organization_Id=1},
                new Donar() { DonorId = 2, Amount = 200, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "srinunani", organization_Id = 1 },
                new Donar() { DonorId = 3, Amount = 200, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "srinunani", organization_Id = 1 }

          };
            mockdonarrepo = new Mock<DonarRepository>();
            mockdonarrepo.Setup(c => c.Get()).Returns(donars);
            mockdonarrepo.Setup(c => c.GetById(1)).Returns(donars[0]);
            
           
        }

        [Test]
        public void GetByIdTest()
        {
            DonarRepository donarRepository = new DonarRepository();
            donarRepository = mockdonarrepo.Object;

            var repo = donarRepository.GetById(1);
            Assert.AreEqual(1, repo.DonorId);
        }
        [Test]
        public  void getAllTest()
        {
            DonarRepository donarRepository = new DonarRepository();
            donarRepository = mockdonarrepo.Object;

            var repo = donarRepository.Get();
            Assert.AreEqual(3,repo.Count());

           
        }

        [Test]
        public void GetByIdFailTest()
        {
            DonarRepository donarRepository = new DonarRepository();
            donarRepository = mockdonarrepo.Object;

            var repo = donarRepository.GetById(1);
            Assert.AreNotEqual(2, repo.DonorId);
        }
        [Test]
        public void getAllFailTest()
        {
            DonarRepository donarRepository = new DonarRepository();
            donarRepository = mockdonarrepo.Object;

            var repo = donarRepository.Get();
            Assert.AreNotEqual(2, repo.Count());


        }



    }
}