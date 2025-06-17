using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        // We can write our custom code here as well
        // if our generic repo does not full fill this
        public UserRepository(PB655Context dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindByUserNameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == username);
        }
    }
}
