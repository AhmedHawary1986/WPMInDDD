using WPM.Management.API.Infrastructure;
using WPM.Management.Domain.Entities;
using WPM.Management.Domain.Interfaces;
using WPM.Management.Domain.ValueObjects;
using WPM.SharedKernel;

namespace WPM.Management.API.Application
{
    public class ManagementApplicationService(IBreedServices breedServices, ManagementDBContext dBContext)
    {
        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.BreedId,breedServices);
            var newPet = new Pet(command.Id, command.Name, command.Age, command.Color, command.SexOfPet, breedId);
            await dBContext.Pets.AddAsync(newPet);
            await dBContext.SaveChangesAsync();
        }

        public async Task Handle(SetWeightCommand command)
        {
          
        }
    }
}
