using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.JwtSigningKey
{
        public class SigningKey
        {
            [Key]
            public Guid Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string KeyId { get; set; }

            // The RSA private key.
            [Required]
            public string PrivateKey { get; set; }

            // The RSA public key in XML or PEM format.
            [Required]
            public string PublicKey { get; set; }
            
            // Indicates if the key is active.
            [Required]
            public bool IsActive { get; set; }
            
            // Date when the key was created.
            [Required]
            public DateTime CreatedAt { get; set; }
            
            // Date when the key is set to expire.
            [Required]
            public DateTime ExpiresAt { get; set; }
        }
}
