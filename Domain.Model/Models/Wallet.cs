using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Casino.Core.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int PlayerId { get; set; }
        [JsonIgnore]
        public virtual Player Player { get; set; }

        public Wallet()
        {

        }

        public Wallet(int playerId)
        {
            Balance = 0;
            PlayerId = playerId;
            
        }
    }
}
