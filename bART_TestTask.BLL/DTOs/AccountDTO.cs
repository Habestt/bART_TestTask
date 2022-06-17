using bART_TestTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.BLL.DTOs
{
    public class AccountDTO
    {        
        public string Name { get; set; }        
        public ContactDTO Contact { get; set; }
    }
}
