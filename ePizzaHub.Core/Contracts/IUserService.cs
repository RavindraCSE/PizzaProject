using ePizzaHub.Models.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Contracts
{
    public interface IUserService 
    {
        public Task<bool> CreateUserRequestAsync(CreateUserRequest createUserRequest);
    }
}
