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
    public class BettingService : IBetService
    {
        private readonly IBetRepository repository;
        private readonly IPlayerRepository playerRepository;
        private readonly IWalletService walletService;
        private readonly IWalletRepository walletRepository;

        public BettingService(IBetRepository repository, IPlayerRepository playerrep, IWalletService service)
        {
            this.repository = repository;
            playerRepository = playerrep;
            walletService = service;

        }

        public async Task<Bet> PlaceBetAsync(string gamename, int player_id, decimal amount)
        {
            var player = await playerRepository.GetPlayer(player_id);
            if (player == null)
            {
                throw new Exception("Player not found");
            }

            await walletService.CashOut(player_id, amount);

            Random random = new Random();
            decimal coefficent = random.Next(2, 4);

            Random rand = new Random();
            bool isWon = rand.Next(0, 2) == 0;

            var bet = new Bet
            {
                PlayerId = player_id,
                GameName = gamename,
                Coeficent = coefficent,
                Result = "Placed",
                isWon = isWon
            };

            if (isWon)
            {
                decimal winAmount = amount * coefficent;
                await walletService.TopUpWallet(player_id, winAmount);

            }

            await repository.AddBet(bet);
            return bet;

        }
    }
}
