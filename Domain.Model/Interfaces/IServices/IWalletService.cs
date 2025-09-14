using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IServices
{
    public interface IWalletService
    {
        Task<decimal> TopUpWallet(int id, decimal money);
        Task<Wallet> GetWallet(int id);
        Task<decimal> CashOut(int id, decimal money);
       
    }
}
