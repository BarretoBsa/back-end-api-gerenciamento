using System;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {

        private DbSet<UserEntity> _dataSet;

        public UserImplementation(MyContext context): base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
