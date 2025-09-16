using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Models
{
    public class PlayerBonus
    {
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }

        public bool IsUsed { get; set; }
    }
}
