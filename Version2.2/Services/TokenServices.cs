using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version2.Services
{
    public class TokenServices : ITokenServices
    {
        public Task<string> ProvideAccessToken()
        {
            return Task.FromResult("");
        }
    }
}
