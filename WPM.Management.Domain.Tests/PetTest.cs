using WPM.Management.Domain.DomainServices;
using WPM.Management.Domain.Entities;
using WPM.Management.Domain.Interfaces;
using WPM.Management.Domain.ValueObjects;
using WPM.SharedKernel;

namespace WPM.Management.Domain.Tests;

public class PetTest
{
    public FakeBreedService breedService = new FakeBreedService();
    [Fact]
    public void Pet_Should_Equal()
    {
        var id = breedService.Breeds[0].Id;

        var petOne = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male,new BreedId(id, breedService));
        var petTwo = new Pet(id, "Mina", 10, "Three-color", SexOfPet.Female, new BreedId(id, breedService));
        Assert.True(petOne.Equals(petTwo));
    }

    [Fact]
    public void Pet_Should_Equal_Using_Operator()
    {
        var id = breedService.Breeds[0].Id;

        var petOne =  new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, new BreedId(id, breedService));
        var petTwo = new Pet(id, "Mina", 10, "Three-color", SexOfPet.Female, new BreedId(id, breedService));
        Assert.True(petOne == petTwo);
    }

    [Fact]
    public void Pet_Should_Not_Equal_Using_Operator()
    {
        var idOne = breedService.Breeds[0].Id;
        var idTwo = breedService.Breeds[1].Id;

        var petOne = new Pet(idOne, "Gianni", 13, "Three-color", SexOfPet.Male, new BreedId(idOne, breedService)) ;
        var petTwo = new Pet(idTwo,"Mina",10,"Three-color",SexOfPet.Female, new BreedId(idTwo, breedService));
        Assert.True(petOne != petTwo);
    }

    [Fact]
    public void Weight_Should_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);

        Assert.True(w1== w2);
    }
}