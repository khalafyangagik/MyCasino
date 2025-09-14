using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IRepositories
{
    public interface IWalletRepository
    {
        Task Add(Wallet  wallet);

        Task<Wallet> GetById(int id);

        Task Update(Wallet wallet);

        Task Delete(Wallet wallet);

    }
}
