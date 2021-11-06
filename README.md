# API Lista de Contatos

Disponível em: https://contactslist.azurewebsites.net/api/v1/

### Método POST:
O método post recebe um JSON com três campos, sendo todos eles obrigatórios:
* *name* -> Nome do contato, não pode ser vazio ou composto por apenas espaços em branco.
* *email* -> Email do contato, deve possuir o caractere "@" e logo na sequencia possuir um domínio que possui pelo menos um caractere "." e terminar com algum caractere alfanumérico.
* *phoneNumber* -> Número de telefone, deve ser enviado como string, possuir apenas números e ter entre 10 e 11 caracteres.

**Retorno**: Código 200 e o objeto JSON enviado, acrescentado do id atribuído ao objeto.

Caso for enviado algum destes campos vazios ou fora do padrão especificado, haverá um retorno de código 400, com um objeto JSON, em que haverá uma chave chamada "message", especificando a validação necessária.

**Exemplo de requisição bem sucedida**:

path: https://contactslist.azurewebsites.net/api/v1/contacts

```json
{
    "name": "Arthur",
    "email": "arthur@gmail.com",
    "phoneNumber": "11994576386"
}
```

**Recebe como retorno**: 200 OK

```json
{
    "id": 1,
    "name": "Arthur",
    "email": "arthur@gmail.com",
    "phoneNumber": "11994576386"
}
```

### Método GET:
O método GET retorna uma lista de JSON com todos os contatos armazenados no banco de dados.

**Exemplo de requisição bem sucedida**:

path: https://contactslist.azurewebsites.net/api/v1/contacts

**Recebe como retorno**: 200 OK
```json
[
  {
    "id": 1,
    "name": "Arthur",
    "email": "arthur@gmail.com",
    "phoneNumber": "11994576386"
  },
  {
    "id": 2,
    "name": "Adriano",
    "email": "adriano@outlook.com",
    "phoneNumber": "1234567890"
  }
]
```
### Método PUT:
O método put necessita passar o id do contato a ser editado na URL da requisição, junto com os seguintes campos:
* *name* -> Nome do contato, não pode ser vazio ou composto por apenas espaços em branco.
* *email* -> Email do contato, deve possuir o caractere "@" e logo na sequencia possuir um domínio que possui pelo menos um caractere "." e terminar com algum caractere alfanumérico.
* *phoneNumber* -> Número de telefone, deve ser enviado como string, possuir apenas números e ter entre 10 e 11 caracteres.

**Retorno**: Código 200 e o objeto JSON enviado acrescentado do id do objeto.

Caso for enviado algum destes campos vazios ou fora do padrão especificado, haverá um retorno de código 400, com um objeto JSON, em que haverá uma chave chamada "message", especificando a validação necessária.

**Exemplo de requisição bem sucedida**:

path: https://contactslist.azurewebsites.net/api/v1/contacts/1
```json
{
    "name": "Artur",
    "email": "artur@gmail.com",
    "phoneNumber": "11994576386"
}
```
**Recebe como retorno**: 200 OK
```json
{
    "id": 1,
    "name": "Artur",
    "email": "artur@gmail.com",
    "phoneNumber": "11994576386"
}
```
### Método Delete:
O método delete necessita apenas do id do contato acrescentado a URL da requisição.

Caso for enviado um id inválido, irá retornar uma badrequest com código 400 e um JSON com uma chave de nome "message" .

**Exemplo de requisição bem sucedida**:

path: https://contactslist.azurewebsites.net/api/v1/contacts/1


**Recebe como retorno**: 200 OK



