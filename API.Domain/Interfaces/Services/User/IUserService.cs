using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> Get(int id);

        Task<IEnumerable<UserEntity>> List();

        Task<UserEntity> Insert(UserEntity anuncio);

        Task<UserEntity> Update(UserEntity anuncio);

        Task<bool> Delete(int id);

    }
}
