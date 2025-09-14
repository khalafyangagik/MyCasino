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
        private readonly IBetRepository repository;
        private readonly IPlayerRepository playerRepository;
        private readonly IWalletRepository walletRepository;

        public UserService(IBetRepository repository, IPlayerRepository playerRepository,IWalletRepository walletRepository)
        {
            this.repository = repository;
            this.playerRepository = playerRepository;
            this.walletRepository = walletRepository;
        }

        public async Task<Player> GetPlayer(int id)
        {
            var player = await playerRepository.GetPlayer(id);
            if (player == null)
            {
                throw new Exception("Player not found");
            }

            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await playerRepository.GetPlayers();
        }

        public async Task<Player> AddPlayer(Player player)
        {
            await playerRepository.AddPlayer(player);
            var wallet = new Wallet { PlayerId = player.Id, Balance = 0 };
            await walletRepository.Add(wallet);     
            player.Wallet = wallet;                   
            return player;
        }
    }
}
