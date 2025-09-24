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
    public class WalletService : IWalletService
    {
        private readonly IRepository<Bet> repository;
        private readonly IRepository<Player> playerRepository;
        private readonly IRepository<Wallet> walletRepository;

        public WalletService(IRepository<Bet> repository, IRepository<Player> playerRepository, IRepository<Wallet> walletRepository)
        {
            this.repository = repository;
            this.playerRepository = playerRepository;
            this.walletRepository = walletRepository;
        }

        public async Task<decimal> CashOut(int id, decimal money)
        {
            var wallet = await walletRepository.Get(id);
            if (wallet == null)
            {
                throw new Exception("Wallet not found");
            }

            if (wallet.Balance < money)
            {
                throw new Exception("Not enough balance");
            }

            wallet.Balance -= money;
            await walletRepository.Update(wallet);

            return wallet.Balance;

        }

        public async Task<Wallet> GetWallet(int id)
        {
            var wallet = await walletRepository.Get(id);
            if (wallet == null)
            {
                throw new Exception("Wallet not found");
            }

            return wallet;
        }

        public async Task<decimal> TopUpWallet(int id, decimal money)
        {
            var wallet = await walletRepository.Get(id);
            if (wallet == null)
            {
                throw new Exception("Wallet not found");
            }

            wallet.Balance += money;
            await walletRepository.Update(wallet);

            return wallet.Balance;
        }
    }
}
