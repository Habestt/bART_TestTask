using Autofac;
using bART_TestTask.BLL.Interfaces;
using bART_TestTask.BLL.Services;
using bART_TestTask.DAL.Interfaces;
using bART_TestTask.DAL.Models;
using bART_TestTask.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bART_TestTask.BLL.Configurations.Autofac
{
    public class Container : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<IncidentRepository>().As<IRepository<Incident>>().SingleInstance();
            builder.RegisterType<AccountRepository>().As<IRepository<Account>>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IRepository<Contact>>().SingleInstance();
            builder.RegisterType<IncidentService>().As<IIncidentService>().SingleInstance();            
        }
    }
}
