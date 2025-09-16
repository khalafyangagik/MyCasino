using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Casino.Core.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        [Range(21, 120, ErrorMessage = "Player must be at least 21 years old.")]
        public int Age { get; set; }


        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public ICollection<PlayerBonus> PlayerBonuses { get; set; } = new List<PlayerBonus>();


        public Player() { }

        public Player(string username,int age)
        {

            Username = username;
            Age = age;
        }
    }
}
