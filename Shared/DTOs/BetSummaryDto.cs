using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class BetSummaryDto
    {
        public int Id { get; set; }
        public string GameName { get; set; } = string.Empty;
        public bool IsWon { get; set; }
    }
}
