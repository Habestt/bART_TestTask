using bART_TestTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.BLL.DTOs
{
    public class IncidentDTO
    {        
        public string Description { get; set; }
        public AccountDTO Account { get; set; }
    }
}
