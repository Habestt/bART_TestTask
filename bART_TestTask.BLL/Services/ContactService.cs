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
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Incident> _incidentRepository;

        public ContactService(IRepository<Contact> contactRepository, IRepository<Account> accountRepository, IRepository<Incident> incidentRepository)
        {
            _contactRepository = contactRepository;
            _accountRepository = accountRepository;
            _incidentRepository = incidentRepository;
        }

        public async Task AddAsync(ContactDTO entity)
        {
            var contacts = await _contactRepository.GetAllAsync();
            Contact contact = AutoMapper<ContactDTO, Contact>.Map(entity);
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(entity.Email);  
            var entityExist = contacts.Where(x => x.Email == entity.Email).FirstOrDefault();

            if (entityExist == null && match.Success)
            {
                await _contactRepository.AddAsync(contact);
            }
            else if (entityExist != null)
            {
                throw new ArgumentException("contact already exist");
            }
            else
            {
                throw new ArgumentException("Incorrect data");
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact> GetByEmailAsync(string contactEmail)
        {
            var contacts = await _contactRepository.GetAllAsync();
            var contact = contacts.Where(x => x.Email == contactEmail).FirstOrDefault();
            if (contact != null)
            {
                return contact;
            }
            else
            {
                throw new ArgumentException("contact was not found");
            }
        }

        public async Task CreateOrUpdateByEmailAsync(ContactForAccDTO entity, string contactEmail)
        {
            var contacts = await _contactRepository.GetAllAsync();
            var existContact = contacts.Where(x => x.Email == contactEmail).FirstOrDefault();
            var existAccount = await _accountRepository.GetByIdAsync(entity.AccountId);

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(contactEmail);

            if (existAccount == null)
            { 
                throw new ArgumentException("Account not exist");
            }

            if (existContact != null)
            {
                existContact.AccountId = entity.AccountId;
                existContact.FirstName = entity.FirstName;
                existContact.LastName = entity.LastName;


                await _contactRepository.UpdateAsync(existContact);
            }
            else if (match.Success)
            {
                Account account = await _accountRepository.GetByIdAsync(entity.AccountId);
                Incident incident = AutoMapper<IncidentForAccDTO, Incident>.Map(entity.Incident);
                await _incidentRepository.AddAsync(incident);

                account.IncidentName = incident.Name;
                await _accountRepository.UpdateAsync(account);

                var contact = new Contact()
                {
                    AccountId = entity.AccountId,
                    Email = contactEmail,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                };

                await _contactRepository.AddAsync(contact);
            }
            else
            {
                throw new ArgumentException("Incorrect email");
            }
        }

    }
}
