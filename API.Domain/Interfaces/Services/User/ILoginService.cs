using System;
using System.Threading.Tasks;
using Domain.Dtos.Login;

namespace Domain.Interfaces.Services.User
{
    public interface ILoginService
    {

        public  Task<object> FindByLogin(LoginDto login);
  
    }
}
