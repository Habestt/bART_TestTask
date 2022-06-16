using bART_TestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.DAL.Context
{
    public class TestTaskContext : DbContext
    {
        DbSet<Incident> Incidents { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Contact> Contacts { get; set; }

        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        {

        }

    }
}
