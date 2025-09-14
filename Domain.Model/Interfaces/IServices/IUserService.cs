using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Player> GetPlayer(int id); 
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> AddPlayer(Player player); 


    }
}
