using bART_TestTask.BLL.Configurations.AutoMapper;
using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using bART_TestTask.DAL.Interfaces;
using bART_TestTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bART_TestTask.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Contact> _contactRepository;

        public AccountService(IRepository<Account> accountRepository, IRepository<Contact> contactRepository)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(AccountDTO entity)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(entity.Contact.Email);

            if (match.Success)
            {
                Account account = AutoMapper<AccountDTO, Account>.Map(entity);
                Contact contact = AutoMapper<ContactDTO, Contact>.Map(entity.Contact);

                if (entity != null && entity.Contact != null)
                {
                    await _accountRepository.AddAsync(account);

                    contact.AccountId = account.Id;
                    await _contactRepository.AddAsync(contact);
                }
                else if (entity.Contact == null)
                {
                    throw new ArgumentException("contacts must be");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect email");
            }
            
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account> GetByNameAsync(string accountName)
        {
            var accounts = await _accountRepository.GetAllAsync();
            var account = accounts.Where(x => x.Name == accountName).FirstOrDefault();
            if (account != null)
            {
                return account;
            }
            else
            {
                throw new ArgumentException("account was not found");
            }

        }
    }
}
