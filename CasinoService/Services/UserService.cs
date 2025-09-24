using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;

namespace CasinoService.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<Bet> repository;
        private readonly IRepository<Player> playerRepository;
        private readonly IRepository<Wallet> walletRepository;
        private readonly IPlayerRepository player;

        public UserService(IRepository<Bet> repository, IRepository<Player> playerRepository,IRepository<Wallet> walletRepository,IPlayerRepository rep)
        {
            this.repository = repository;
            this.playerRepository = playerRepository;
            this.walletRepository = walletRepository;
            this.player = rep;
        }

        public async Task<Player> GetPlayer(int id)
        {
            var player = await playerRepository.Get(id);
            if (player == null)
            {
                throw new Exception("Player not found");
            }

            return player;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            await playerRepository.Create(player);
            var wallet = new Wallet { PlayerId = player.Id, Balance = 0 };
            await walletRepository.Create(wallet);     
            player.Wallet = wallet;                   
            return player;
        }


        public async Task<List<Player?>> GetRichPlayers()
        {
            return await player.GetRichPlayers();
        }

        public async Task Delete(int id)
        {
            await playerRepository.Delete(id);
        }
    }
}
