using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public decimal Coeficent { get; set; }
        public string Result { get; set; }
        public bool isWon {  get; set; }

        public int PlayerId { get; set; }
        public virtual Player player { get; set; }

        public Bet() { }
        public Bet(string gameName,int playerId)
        {
            GameName = gameName;
            Result = "Preparing";
            PlayerId = playerId;
            isWon = false;
        }

    }
}
