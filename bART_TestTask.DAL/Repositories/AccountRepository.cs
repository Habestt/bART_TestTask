using bART_TestTask.DAL.Context;
using bART_TestTask.DAL.Models;
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
    }
}
