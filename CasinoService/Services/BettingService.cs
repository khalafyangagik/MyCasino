using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;

namespace CasinoService.Services
{
    public class BettingService : IBetService
    {
        private readonly IRepository<Bet> repository;
        private readonly IRepository<Player> playerRepository;
        private readonly IWalletService walletService;
        private readonly IRepository<Wallet> walletRepository;
        private readonly IBetRepository betRepo;
        private static readonly Random _random = new Random();
        public BettingService(IRepository<Bet> repository, IRepository<Player> playerrep, IWalletService service,IBetRepository repo)
        {
            this.repository = repository;
            playerRepository = playerrep;
            walletService = service;
            betRepo = repo;

        }

        public async Task<Bet> PlaceBetAsync(string gamename, int player_id, decimal amount)
        {
            var player = await playerRepository.Get(player_id);
            if (player == null)
            {
                throw new Exception("Player not found");
            }

            await walletService.CashOut(player_id, amount);


            decimal coefficent = _random.Next(2, 5);


            bool isWon = _random.Next(0, 2) == 1;

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

            await repository.Create(bet);
            return bet;
        }

            public async Task<IList<Bet>> GetAllBets(int userId)
            {
               return await betRepo.GetAllBets(userId);
            }

        }
    }

