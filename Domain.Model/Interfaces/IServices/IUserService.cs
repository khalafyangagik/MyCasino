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
        Task<Player> AddPlayer(Player player);
        Task<List<Player>> GetRichPlayers();
        Task Delete(int id);

    }
}
