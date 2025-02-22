using Microsoft.EntityFrameworkCore;
using WPM.Management.Domain.Entities;
using WPM.Management.Domain.Repository;

namespace WPM.Management.API.Infrastructure
{
    public class ManagementRepository(ManagementDBContext dBContext) : ImanagementRepository
    {
        public void Delete(Pet pet)
        {
            dBContext.Remove(pet);
        }

        public async Task<IEnumerable<Pet>> GetAll()
        {
            var pets = await dBContext.Pets.ToListAsync();
            return pets;
        }

        public async Task<Pet> GetById(Guid id)
        {
           var pet = await dBContext.Pets.FindAsync(id);
            return pet;
        }

        public async Task Insert(Pet pet)
        {
           await  dBContext.AddAsync(pet);
        }

        public async Task Update(Pet pet)
        {
            var petDb = await dBContext.Pets.FindAsync(pet.Id);
            petDb = pet;
            await dBContext.SaveChangesAsync();
        }
    }
}
