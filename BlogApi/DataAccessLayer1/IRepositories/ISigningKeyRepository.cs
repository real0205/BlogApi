using DomainLayer.Models.JwtSigningKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    interface ISigningKeyRepository
    {
        SigningKey GetActiveSiginingKey();
        List<SigningKey> GetAllSigningKey();
    }
}
