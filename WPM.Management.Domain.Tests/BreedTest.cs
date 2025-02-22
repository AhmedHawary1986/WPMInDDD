using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain.ValueObjects;
using WPM.Management.Domain.DomainServices;
using WPM.Management.Domain.Entities;

namespace WPM.Management.Domain.Tests
{
    public class BreedTest
    {
        [Fact]

        public void WeightRange_Should_Equal()
        {
            WeightRange w1 = new WeightRange(10.5m, 20.5m);
            WeightRange w2 = new WeightRange(10.5m, 20.5m);

            Assert.True(w1.Equals(w2));
        }

        [Fact]
        public void BreedId_Should_be_valid()
        {
            var breedSevice = new FakeBreedService();

            var Id = breedSevice.Breeds[0].Id;

            var breedId = new BreedId(Id, breedSevice);

            Assert.NotNull(breedId);
        }

        [Fact]
        public void BreedId_Should_Not_be_valid()
        {
            var breedSevice = new FakeBreedService();

            var Id = Guid.NewGuid();
            Assert.Throws<ArgumentException>(() =>
            {
                var breedId = new BreedId(Id, breedSevice);

            });
           

     
        }

        [Fact]

        public void Bread_Should_be_Ideal()
        {
            var breadService = new FakeBreedService();
            var Id = breadService.Breeds[0].Id;

            var breadId = new BreedId(Id, breadService);

            var pet = new Pet(Guid.NewGuid(), "Gianni", 13, "Three-color", SexOfPet.Male, breadId);

            pet.SetWeight(15, breadService);

            Assert.True(pet.WeightClass == WeightClass.Ideal);
        }

        [Fact]
        public void Bread_Should_be_UnderWeight()
        {
            var breadService = new FakeBreedService();
            var Id = breadService.Breeds[0].Id;

            var breadId = new BreedId(Id, breadService);

            var pet = new Pet(Guid.NewGuid(), "Gianni", 8, "Three-color", SexOfPet.Male, breadId);

            pet.SetWeight(8, breadService);

            Assert.True(pet.WeightClass == WeightClass.UnderWeight);
        }

        [Fact]
        public void Bread_Should_be_OverWeight()
        {
            var breadService = new FakeBreedService();
            var Id = breadService.Breeds[0].Id;

            var breadId = new BreedId(Id, breadService);

            var pet = new Pet(Guid.NewGuid(), "Gianni", 30, "Three-color", SexOfPet.Male, breadId);

            pet.SetWeight(30, breadService);

            Assert.True(pet.WeightClass == WeightClass.OverWeight);
        }
    }
}
