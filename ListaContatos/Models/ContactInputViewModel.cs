using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsList.Models
{
    public class ContactInputViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
    }
}
