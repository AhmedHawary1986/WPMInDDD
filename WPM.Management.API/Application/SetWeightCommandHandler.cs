
using Microsoft.EntityFrameworkCore;
using WPM.Management.API.Infrastructure;
using WPM.Management.Domain.Interfaces;
using WPM.SharedKernel;

namespace WPM.Management.API.Application
{
    public class SetWeightCommandHandler(IBreedServices breedServices, ManagementDBContext dBContext) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await dBContext.Pets.FindAsync(command.Id);
            if (pet != null)
            {
                Weight weight = new Weight(command.Weight);
                pet.SetWeight(weight, breedServices);
                await dBContext.SaveChangesAsync();
            }
        }
    }
}
