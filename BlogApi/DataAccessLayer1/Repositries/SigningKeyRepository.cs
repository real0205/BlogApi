using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models.BlogModels;
using DomainLayer.Models.JwtSigningKey;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositries
{
    public class SigningKeyRepository : ISigningKeyRepository
    {
        private readonly ApplicationDbContext _context;
        public SigningKeyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public SigningKey GetActiveSiginingKey()
        {
            return _context.SigningKeys.FirstOrDefault(k => k.IsActive);
        }

        public List<SigningKey> GetAllSigningKey()
        {
            return _context.SigningKeys.Where(k => k.IsActive).ToList();
        }
    }
}
