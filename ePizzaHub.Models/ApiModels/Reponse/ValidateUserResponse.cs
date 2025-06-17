using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Models.ApiModels.Reponse
{
    public class ValidateUserResponse
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
