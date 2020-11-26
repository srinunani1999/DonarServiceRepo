using DonarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonarService.Repositories
{
    public class DonarRepository : IRepository<Donar>
    {
        public int MyProperty { get; set; }
        static List<Donar> donars { get; set; }
        static DonarRepository()
        {
            donars = new List<Donar>() {

                new Donar() { DonorId=1,Amount=100,DateOfDonation=DateTime.Parse("10-10-2020"),DonorName="srinu",organization_Id=1},
                new Donar() { DonorId = 2, Amount = 200, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "srinunani", organization_Id = 1 },
                new Donar(){ DonorId = 2, Amount = 200, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "kodati", organization_Id = 2 },
                new Donar() { DonorId = 3, Amount = 300, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "1120", organization_Id = 3 },
                new Donar() { DonorId = 4, Amount = 400, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "net", organization_Id = 2 },
                new Donar() { DonorId = 5, Amount = 100, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "philips", organization_Id = 1 },
                new Donar (){ DonorId = 6, Amount = 200, DateOfDonation = DateTime.Parse("10-10-2020"), DonorName = "srinu", organization_Id = 2 }


          };

        }
        public virtual void Add(Donar donar)
        {
            donars.Add(donar);
        }

        public virtual IEnumerable<Donar> Get()
        {
            return donars;
        }

        public virtual Donar GetById(int id)
        {
           var donar= donars.FirstOrDefault(d => d.DonorId == id);
            return donar;
        }
    }
}
