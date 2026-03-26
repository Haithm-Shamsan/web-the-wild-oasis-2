using Api_WildOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildOasis.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int personId);
        Task<Person> AddPersonAsync(Person newPerson);
        Task<Person> UpdatePersonAsync(int personId, Person updatedPerson);
        Task<bool> DeletePersonAsync(int personId);
    }
}
