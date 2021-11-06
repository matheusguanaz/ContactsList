using ContactsList.Business.Entities;
using ContactsList.Business.Repositories;
using ContactsList.Helpers;
using ContactsList.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsList.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactsListController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactsListController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao atualizar o contato")]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        public IActionResult Put(ContactInputViewModel contactInputViewModel, string id)
        {
            Contact contact = new()
            {
                Name = contactInputViewModel.Name,
                Email = contactInputViewModel.Email,
                phoneNumber = contactInputViewModel.phoneNumber
            };


            ValidateInputs validate = new();

            if (!validate.ValidateId(id))
                return BadRequest(new { message = $"id inválido" });

            if (!validate.ValidateName(contactInputViewModel.Name))
                return BadRequest(new { message = "Campo name é necessário " });

            if (!validate.ValidateEmail(contactInputViewModel.Email))
                return BadRequest(new { message = "Insira o email no formato correto" });

            if (!validate.ValidatePhoneNumber(contactInputViewModel.phoneNumber))
                return BadRequest(new { message = "Insira apenas numeros entre 10 e 11 caracteres" });

            var contactUpdate = _contactRepository.Update(contact, Convert.ToInt32(id));

            return Ok(contactUpdate);
        }

        /// <summary>
        /// Método Post, que irá receber um contactInputViewModel e chamar o repository para inserção
        /// </summary>
        /// <param name="contactInputViewModel">Modelo de entrada de dados que´será recebido pela API</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao inserir o contato")]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        public IActionResult Post(ContactInputViewModel contactInputViewModel)
        {
            Contact contact = new()
            {
                Name = contactInputViewModel.Name,
                Email = contactInputViewModel.Email,
                phoneNumber = contactInputViewModel.phoneNumber
            };

            ValidateInputs validate = new();

            if (!validate.ValidateName(contactInputViewModel.Name))
                return BadRequest(new { message = "Campo name é necessário " });

            if (!validate.ValidateEmail(contactInputViewModel.Email))
                return BadRequest(new { message ="Insira o email no formato correto" });

            if (!validate.ValidatePhoneNumber(contactInputViewModel.phoneNumber))
                return BadRequest(new {message = "Insira apenas numeros entre 10 e 11 caracteres"});


            var contactCreated = _contactRepository.Add(contact);
            return Created("", contactCreated);
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(statusCode: 200, description: "Contato excluído com sucesso")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        public IActionResult Delete(string id)
        {
            ValidateInputs validate = new();
            if(!validate.ValidateId(id))
                return BadRequest(new { message = $"id inválido" });

            if (_contactRepository.Delete(Convert.ToInt32(id)))
                return Ok();
            return BadRequest(new { message = $"Contato com o id {id} não encontrado" });

        }

        /// <summary>
        /// Retorna todos os contatos da lista de contatos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(statusCode: 200, description: "Contatos retornados com sucesso")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        public IActionResult GetAll()
        {
            var contacts = _contactRepository.GetAll();

            return Ok(contacts);
        }
    }
}
