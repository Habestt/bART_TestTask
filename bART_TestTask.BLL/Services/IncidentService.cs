using bART_TestTask.BLL.Configurations.AutoMapper;
using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using bART_TestTask.DAL.Interfaces;
using bART_TestTask.DAL.Models;
using bART_TestTask.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.BLL.Services
{
    public class IncidentService : IIncidentService
    {
        public readonly IRepository<Incident> _incidentRepository;
        public readonly IRepository<Account> _accountRepository;
        public readonly IRepository<Contact> _contactRepository;

        public IncidentService(IRepository<Incident> incidentRepository, IRepository<Account> accountRepository, IRepository<Contact> contactRepository)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(IncidentDTO entity)
        {            
            Incident incident = AutoMapper<IncidentDTO, Incident>.Map(entity);
            Account account = AutoMapper<AccountDTO, Account>.Map(entity.Account);            
            Contact contact = AutoMapper<ContactDTO, Contact>.Map(entity.Account.Contact);

            if (entity != null && entity.Account != null && entity.Account.Contact != null)
            {
                await _incidentRepository.AddAsync(incident);

                account.IncidentName = incident.Name;
                await _accountRepository.AddAsync(account);

                contact.AccountId = account.Id;
                await _contactRepository.AddAsync(contact);
            }
            else
            {
                throw new ArgumentException("account and contacts must be");
            }
        }

        public async Task AddForAccAsync(IncidentForAccDTO entity)
        {
            Account user = await _accountRepository.GetByIdAsync(entity.AccountId);

            if (user != null && user.IncidentName == null)
            {
                Incident incident = AutoMapper<IncidentForAccDTO, Incident>.Map(entity);
                await _incidentRepository.AddAsync(incident);
                user.IncidentName = incident.Name;
                await _accountRepository.UpdateAsync(user);
            }
            else if (user.IncidentName != null)
            {
                throw new ArgumentException("user alredy have an incident");
            }
            else
            {
                throw new ArgumentException("user can not be found");
            }
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {            
            return await _incidentRepository.GetAllAsync();
        }

        public async Task<Incident> GetByIdAsync(int id)
        {
            return await _incidentRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            await _incidentRepository.RemoveAsync(await _incidentRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(IncidentDTO entity)
        {
            await _incidentRepository.UpdateAsync(AutoMapper<IncidentDTO, Incident>.Map(entity));
        }
    }
}
