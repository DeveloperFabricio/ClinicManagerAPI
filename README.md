## Clinic Manager API 🌐

#### Este projeto é uma API web que implementa um sistema de gerenciamento de um clinica.
#### A API permite que a clinica tenha controle total de: Médicos, Pacientes, Atendimento.
#### Anexos contendo: Atestado, Receita, Evolução do paciente.
#### Paciente pode ser encontrado pelo CPF e Celular, e ainda recebe uma confirmação de agendamento por e-mail e Google Agenda.


### Funcionalidades 🖥️  ☑ (Concluído) ⌛ (Fazendo)


- ☑ CRUD Paciente Busca Por CPF (e celular)
- ☑ CRUD Médico
- ☑ CRUD Atendimento
- ☑ CRUD Serviço
- ⌛ PLUS 2: Confirmação de Agendamento (Email/SMS + Google Agenda).
- ⌛ PLUS 2: Background Service rodando e notificando no dia anterior.
- ⌛ PLUS 2: Autenticação e Autorização Perfis: Médico, Administrador, Receptionista.
- ☑ PLUS 2: CRUD DE ANEXO Tipos: Atestado, Receita, Evolução.
  

### Tecnologias utilizadas 💡


- ASP.NET Core 7: framework web para desenvolvimento de aplicações .NET
- Entity Framework Core: persistência e consulta de dados.
- SQL Server: banco de dados relacional.
  

### Padrões, conceitos e arquitetura utilizada 📂


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

  Instalação
Requisitos
Antes de iniciar, certifique-se de ter os seguintes requisitos instalados:

.NET SDK 7.0: A versão do .NET Framework necessária para executar a API.
SQL Server: O banco de dados utilizado para armazenar os dados.
Clone
Clone o repositório do GitHub:

bash
Copy code
git clone https://github.com/[seu-usuário]/BloodBankManager.API.git
Navegação
Navege até a pasta do projeto:

bash
Copy code
cd BloodBankManager.API
IDE
Abra o projeto na sua IDE de preferência (a IDE utilizada para desenvolvimento foi o Visual Studio).

Restauração de Pacotes
Restaure os pacotes necessários:

bash
Copy code
dotnet restore
Configuração do Banco de Dados
Abra o arquivo appsettings.json.
Altere as configurações do banco de dados para corresponder ao seu ambiente.
Execução da API
Para executar a API, use o seguinte comando:

bash
Copy code
dotnet run
