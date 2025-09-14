using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int PlayerId { get; set; }
    }
}
