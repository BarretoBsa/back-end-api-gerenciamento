using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<UserEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<UserEntity> Insert(UserEntity user)
        {
            return await _repository.Insert(user);
        }

        public async Task<IEnumerable<UserEntity>> List()
        {
            return (IEnumerable<UserEntity>)await _repository.List();
        }

        public async Task<UserEntity> Update(UserEntity user)
        {
            return await _repository.Update(user);
        }
    }
}
