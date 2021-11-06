using ContactsList.Business.Entities;
using ContactsList.Business.Repositories;
using ContactsList.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsList.Infraestructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza um contato no banco de dados
        /// </summary>
        /// <param name="contact">O novo contato</param>
        /// <param name="id">o id do contato</param>
        /// <returns></returns>
        public Contact Update(Contact contact, int id)
        {
            var contactInDB = _context.Contact.SingleOrDefault(c => c.Id == id);
            contactInDB.Name = contact.Name;
            contactInDB.Email = contact.Email;
            contactInDB.phoneNumber = contact.phoneNumber;

            _context.SaveChanges();
            return contactInDB;
        }
        /// <summary>
        /// Adiciona o contato ao banco de dados e persiste a inserção
        /// </summary>
        /// <param name="contact">O contato a ser inserido</param>
        /// <returns>O contato que foi inserido, contendo o Id</returns>
        public Contact Add(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        /// <summary>
        /// Remove contato do banco de dados
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            var contactToBeRemoved = _context.Contact.SingleOrDefault(c => c.Id == id);
            if (contactToBeRemoved == null)
                return false;

            _context.Remove(contactToBeRemoved);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Obtem todos os contatos salvos no banco de dados
        /// </summary>
        /// <returns></returns>
        public IList<Contact> GetAll()
        {
           var contacts =  _context.Contact.ToList();
           return contacts;
        }
    }
}
