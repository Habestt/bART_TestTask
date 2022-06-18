using bART_TestTask.DAL.Context;
using bART_TestTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.DAL.Repositories
{
    public class ContactRepository : Repository<Contact>
    {
        private readonly TestTaskContext _context;
        public ContactRepository(TestTaskContext context) : base(context)
        {
            _context = context;
        }        
    }
}
