using bART_TestTask.DAL.Context;
using bART_TestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.DAL.Repositories
{
    public class AccountRepository : Repository<Account>
    {
        public readonly TestTaskContext _context;
        public AccountRepository(TestTaskContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Account>> GetAllAsync()
        {            
            await _context.Set<Contact>().ToListAsync();
            return await base.GetAllAsync();
        }
    }
}
