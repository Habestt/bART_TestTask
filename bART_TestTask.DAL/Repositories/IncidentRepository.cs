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
    public class IncidentRepository : Repository<Incident>
    {
        public readonly TestTaskContext _context;
        public IncidentRepository(TestTaskContext context) : base(context)
        {
            _context = context;
        }    

        public override async Task<IEnumerable<Incident>> GetAllAsync()
        {
            await _context.Set<Account>().ToListAsync();
            await _context.Set<Contact>().ToListAsync();
            return await base.GetAllAsync();
        }
    }
}
