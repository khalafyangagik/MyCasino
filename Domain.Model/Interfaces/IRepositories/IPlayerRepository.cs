using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task AddPlayer(Player player);
        Task<Player> GetPlayer(int id);
        Task<IEnumerable<Player>> GetPlayers();
        Task DeletePlayer(Player player);
    }
}
