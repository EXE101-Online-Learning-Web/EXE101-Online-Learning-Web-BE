using OnlineLearningLibrary.DTOs;
using OnlineLearningLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningLibrary.Service.IService
{
    public interface IAccountService
    {
        Task<Account?> GetAccountByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task UpdateAccountAsync(int id, AccountDTO updatedAccountDTO);
    }
}
