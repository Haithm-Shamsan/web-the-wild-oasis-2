using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_WildOasis.Entities;
using Api_WildOasis.Data;
using Microsoft.EntityFrameworkCore;
using WildOasis.Core.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace WildOasis.Infrastructure.Repositories
{




    public class CabinsRepository : ICabinsRepository
    {
        private readonly WildOasisContext _context;

        public CabinsRepository(WildOasisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cabin>> GetAllCabinsAsync()
        {
            return await _context.Cabins.ToListAsync();
        }

        public async Task<Cabin> GetCabinByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            return await _context.Cabins.FirstOrDefaultAsync(cabin => cabin.Id == id);
        }

        public async Task<Cabin> AddCabinAsync(Cabin newCabin)
        {
            _context.Cabins.Add(newCabin);
            await _context.SaveChangesAsync();
            return newCabin;
        }

        public async Task<Cabin> UpdateCabinAsync(int id, Cabin updatedCabin)
        {
            var existingCabin = await _context.Cabins.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCabin == null) return null;

            existingCabin.Name = updatedCabin.Name ?? existingCabin.Name;
            existingCabin.MaxCapacity = updatedCabin.MaxCapacity != 0 ? updatedCabin.MaxCapacity : existingCabin.MaxCapacity;
            existingCabin.RegularPrice = updatedCabin.RegularPrice != 0 ? updatedCabin.RegularPrice : existingCabin.RegularPrice;
            existingCabin.Discount = updatedCabin.Discount != 0 ? updatedCabin.Discount : existingCabin.Discount;
            existingCabin.Description = updatedCabin.Description ?? existingCabin.Description;
            existingCabin.Image = updatedCabin.Image ?? existingCabin.Image;

            // Save changes to the database
            _context.Cabins.Update(existingCabin);
            await _context.SaveChangesAsync();

            // Return the updated cabin
            return existingCabin;
         
        }

        public async Task<bool> DeleteCabinAsync(int id)
        {
            var cabin = await _context.Cabins.FirstOrDefaultAsync(c => c.Id == id);
            if (cabin == null) return false;

            _context.Cabins.Remove(cabin);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
