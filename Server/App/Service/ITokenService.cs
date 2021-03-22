using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
