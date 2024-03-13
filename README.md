## Clinic Manager 

#### Este projeto é uma API web que implementa um sistema de gerenciamento de um clinica.
#### A API permite que a clinica tenha controle total de: Médicos, Pacientes, Atendimento.
#### Anexos contendo: Atestado, Receita, Evolução do paciente.
#### Paciente pode ser encontrado pelo CPF e Celular, e ainda recebe uma confirmação de agendamento por e-mail e Google Agenda.

### Funcionalidades 

- ☑ CRUD Paciente Busca Por CPF (e celular)
- ☑ CRUD Médico
- ☑ CRUD Atendimento
- ☑ CRUD Serviço
- ⌛ PLUS 2: Confirmação de Agendamento (Email/SMS + Google Agenda).
- ⌛ PLUS 2: Background Service rodando e notificando no dia anterior.
- ⌛ PLUS 2: Autenticação e Autorização Perfis: Médico, Administrador, Receptionista.
- ☑ PLUS 2: CRUD DE ANEXO Tipos: Atestado, Receita, Evolução.

### Tecnologias utilizadas 

- ASP.NET Core 7
- Entity Framework Core
- SQL Server

### Padrões, conceitos e arquitetura utilizada 

- ☑ Fluent Validation
- ☑ Padrão Repository
- ☑ Middleware (Lidar com exceções)
- ⌛ InputModel, ViewModel
- ☑ DTO’s 
- ☑ IEntityTipeConfiguration 
- ☑ Sql Server 
- ⌛ Unit Of Work
- ⌛ HostedService
- ⌛ Domain Event
- ⌛ CQRS
- ☑ Teste Unitários
- ☑ Arquitetura Limpa
