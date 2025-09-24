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
        Task<List<Player?>> GetRichPlayers();
    }
}
