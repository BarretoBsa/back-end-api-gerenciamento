using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Service.Service
{
    public class AnuncioService : IAnuncioService
    {
        private IRepository<AnuncioEntity> _repository;

        public AnuncioService(IRepository<AnuncioEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<AnuncioEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<AnuncioEntity>> List()
        {
            return (IEnumerable<AnuncioEntity>)await  _repository.List();
        }

        public async Task<AnuncioEntity> Insert(AnuncioEntity user)
        {
            return await _repository.Insert(user);
        }

        public async Task<AnuncioEntity> Update(AnuncioEntity user)
        {
            return await _repository.Update(user);
        }
    }
}
