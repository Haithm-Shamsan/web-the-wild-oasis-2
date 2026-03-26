using Api_WildOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildOasis.Core.Interfaces
{
   
    
        public interface ICabinsRepository
        {
            Task<IEnumerable<Cabin>> GetAllCabinsAsync();
      
            Task<Cabin> GetCabinByIdAsync(int id);
            Task<Cabin> AddCabinAsync(Cabin newCabin);
            Task<Cabin> UpdateCabinAsync(int id, Cabin updatedCabin);
            Task<bool> DeleteCabinAsync(int id);
        }
    
}
