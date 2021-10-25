using System;
using System.Collections;
using System.Threading.Tasks;
using API.Domain.Entities;
using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<T> :  IRepository<T> where T: BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;


        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> Delete(int id)
        {
            try {

                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;



            }
            catch (Exception ex) { throw ex; }

        }

        
        public async Task<T> Get(int id)
        {
            try {

                var result = await _dataset.SingleOrDefaultAsync(p=>p.Id.Equals(id));

                if (result == null)
                    return null;

                return result;


            } catch (Exception ex) { throw ex; }
        }

        public async Task<T> Insert(T item)
        {
            try{
               
                _dataset.Add(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
         
        }

        public async Task<IEnumerable> List()
        {
            try {
                return await _dataset.ToListAsync();

            } catch (Exception ex) { throw ex; }
        }

        public async Task<T> Update(T item)
        {
            try {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }


            return item;
        }
    }
}
