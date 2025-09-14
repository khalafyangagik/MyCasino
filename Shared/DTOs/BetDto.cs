using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public string GameName { get; set; } = string.Empty;
        public decimal Coeficent { get; set; }
        public string Result { get; set; } = string.Empty;
        public bool IsWon { get; set; }
        public int PlayerId { get; set; }
    }
}
