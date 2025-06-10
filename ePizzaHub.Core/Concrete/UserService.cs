using AutoMapper;
using ePizzaHub.Core.Contracts;
using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Models.ApiModels.Request;
using ePizzaHub.Repositories.Concrete;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper=mapper;


        }
        public async Task<bool> CreateUserRequestAsync(CreateUserRequest createUserRequest)
        {
            // all business logic here
            // 1: insert record in user and user role table
            // 2 : Hash the password sending my end user

            var roleDetails = _roleRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();
            if (roleDetails != null)
            {
                var user = _mapper.Map<User>(createUserRequest);
                user.Roles.Add(roleDetails);
                // Downlad BCrypt nuget package manager
                user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password);
                await _userRepository.AddAsync(user);
                int rowsInserted = await _userRepository.CommitAsync();
                return rowsInserted > 0;

            }

            return false;
        }
    }
}
