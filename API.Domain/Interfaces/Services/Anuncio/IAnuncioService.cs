using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IAnuncioService
    {
        Task<AnuncioEntity> Get(int id);

        Task<IEnumerable<AnuncioEntity>> List();

        Task<AnuncioEntity> Insert(AnuncioEntity anuncio);

        Task<AnuncioEntity> Update(AnuncioEntity anuncio);

        Task<bool> Delete(int id);
    }
}
