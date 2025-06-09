using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.ApiModels.Request;
using ePizzaHub.Repositories.Concrete;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;


        }
        public Task<bool> CreateUserRequestAsync(CreateUserRequest createUserRequest)
        {
            // all business logic here
            // 1: insert record in user and user role table
            // 2 : Hash the password sending my end user

            var roleDetails = _roleRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();
            if (roleDetails != null)
            {

            }

            throw new NotImplementedException();
        }
    }
}
