using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IAccountService
    {
        Task<Account?> GetAccountByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task UpdateAccountAsync(int id, AccountDTO updatedAccountDTO);
    }
}
