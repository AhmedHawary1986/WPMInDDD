using System.Numerics;
using WPM.Management.Domain.Interfaces;
using WPM.Management.Domain.ValueObjects;
using WPM.SharedKernel;

namespace WPM.Management.Domain.Entities;

public class Pet : Entity
{

    public string Name { get; init; }
    public int Age { get; init; }

    public string Color { get; init; }

    public Weight? Weight { get; private set; }

    public WeightClass WeightClass { get; private set; }

    public SexOfPet SexOfPet { get; init; }

    public BreedId BreedId { get; init; }



    public Pet(Guid id,
               string name,
               int age,
               string color,
               
               SexOfPet sexOfPet,
               BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
    
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }

    public void SetWeight(Weight weight,IBreedServices breadServices)
    {
        Weight = weight;
        setWeightClass(breadServices);
    }
    private void setWeightClass(IBreedServices breedService)
    {
        var breed = breedService.GetBreed(BreedId.Value);

        var (from, to) = SexOfPet switch
        {
           SexOfPet.Male => (breed.MaleRange.From, breed.MaleRange.To),
           SexOfPet.Female => (breed.FemaleRange.From, breed.FemaleRange.To),
           _ => throw new NotImplementedException() 
        };

        WeightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClass.UnderWeight,
            _ when Weight.Value > to => WeightClass.OverWeight,
            _ => WeightClass.Ideal
        };
    }
}

public enum SexOfPet
{
    Male = 1,
    Female = 2,
}

public enum WeightClass
{
    Unknown=1,
    Ideal=2,
    UnderWeight=3,
    OverWeight=4
}
