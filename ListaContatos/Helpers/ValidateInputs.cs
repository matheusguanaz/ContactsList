using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsList.Helpers
{
    public class ValidateInputs
    {
        /// <summary>
        /// Verifica se o id é um número e é válido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ValidateId(string id)
        {
            Regex rgx = new("^[0-9]");
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id) || !rgx.IsMatch(id))
                return false;

            return true;
        }
        /// <summary>
        /// Verifica se o campo nome foi preenchido
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;

            return true;
        }
        /// <summary>
        /// Verifica se o email está no formato correro
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            Regex rgx = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (string.IsNullOrWhiteSpace(email) || !rgx.IsMatch(email) || string.IsNullOrEmpty(email))
                return false;

            return true;
        }
        /// <summary>
        /// Faz a validação se o numero de telefone esta entre 10 e 11 caracteres e possui apenas numeros 
        /// </summary>
        /// <param name="phoneNumber">número de telefone</param>
        /// <returns></returns>
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            Regex rgx = new("^[0-9]");
            if(!rgx.IsMatch(phoneNumber) || phoneNumber.Length < 10 || phoneNumber.Length > 11 || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            return true;
        }
    }
}
