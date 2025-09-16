using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public decimal Amount { get; set; } 
        public DateTime ExpiryDate { get; set; }

        public ICollection<PlayerBonus> PlayerBonuses { get; set; } = new List<PlayerBonus>();
    }
}
