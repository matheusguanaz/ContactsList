using ContactsList.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsList.Business.Repositories
{
    public interface IContactRepository
    {
        bool Delete(int id);
        Contact Update(Contact contact, int id);
        Contact Add(Contact contact);
        IList<Contact> GetAll();
    }
}
