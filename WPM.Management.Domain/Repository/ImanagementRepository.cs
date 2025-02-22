using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain;
using WPM.Management.Domain.Entities;

namespace WPM.Management.Domain.Repository
{
    public interface ImanagementRepository
    {
        Task<Pet> GetById(Guid id);

        Task<IEnumerable<Pet>> GetAll();

        Task Insert(Pet pet);
        
        Task Update(Pet pet);

        void Delete(Pet pet);
    }
}
