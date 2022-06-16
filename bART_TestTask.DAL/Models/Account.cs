using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_TestTask.DAL.Models
{
    public class Account
    {              
        public int Id { get; set; }
        public string Name { get; set; }        
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
