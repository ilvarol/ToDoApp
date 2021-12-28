using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Services
{
    public interface IJWTService
    {
        string GenerateJSONWebToken(IEnumerable<Claim> claims);
    }
}