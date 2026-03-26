using Api_WildOasis.Data;
using Api_WildOasis.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildOasis.Core.Interfaces;

namespace WildOasis.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly WildOasisContext _context;

        public PersonRepository(WildOasisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.PersonId == personId);
        }

        public async Task<Person> AddPersonAsync(Person newPerson)
        {
            _context.People.Add(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Person> UpdatePersonAsync(int personId, Person updatedPerson)
        {
            var existingPerson = await _context.People.FirstOrDefaultAsync(p => p.PersonId == personId);
            if (existingPerson == null) return null;

            existingPerson.FullName = updatedPerson.FullName ?? existingPerson.FullName;
            existingPerson.Email = updatedPerson.Email ?? existingPerson.Email;
            existingPerson.NationalId = updatedPerson.NationalId ?? existingPerson.NationalId;
            existingPerson.Nationality = updatedPerson.Nationality ?? existingPerson.Nationality;
            existingPerson.CountryFlag = updatedPerson.CountryFlag ?? existingPerson.CountryFlag;

            await _context.SaveChangesAsync();
            return existingPerson;
        }

        public async Task<bool> DeletePersonAsync(int personId)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.PersonId == personId);
            if (person == null) return false;

            _context.People.Remove(person);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
