//using OnlineLearningWebAPI.DTOs;
//using OnlineLearningWebAPI.Models;
//using OnlineLearningWebAPI.Repository.IRepository;
//using OnlineLearningWebAPI.Service.IService;

//namespace OnlineLearningWebAPI.Service
//{
//    public class AccountService: IAccountService
//    {
//        private readonly IRepository<Account> _accountRepository;

//        public AccountService(IRepository<Account> accountRepository)
//        {
//            _accountRepository = accountRepository;
//        }

//        public async Task<Account?> GetAccountByIdAsync(int id)
//        {
//            return await _accountRepository.GetByIdAsync(id);
//        }

//        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
//        {
//            return await _accountRepository.GetAllAsync();
//        }

//        public async Task UpdateAccountAsync(int id, AccountDTO updatedAccountDTO)
//        {
//            var account = await _accountRepository.GetByIdAsync(id);
//            if (account == null) throw new Exception("[AccountService] | UpdateAccountAsync | Account not found");

//            account.Email = updatedAccountDTO.Email ?? account.Email;
//            account.FullName = updatedAccountDTO.FullName ?? account.FullName;
//            account.Avatar = updatedAccountDTO.Avatar ?? account.Avatar;
//            account.IsVip = updatedAccountDTO.IsVip ?? account.IsVip;

//            _accountRepository.Update(account);
//            await _accountRepository.SaveChangesAsync();
//        }
//    }
//}
