# LoginSystemAPI

![Badge](https://img.shields.io/badge/Status-Concluído-green)
![GitHub issues](https://img.shields.io/github/issues/SeuUsuario/LoginSystemAPI)
![GitHub stars](https://img.shields.io/github/stars/SeuUsuario/LoginSystemAPI)
![GitHub forks](https://img.shields.io/github/forks/SeuUsuario/LoginSystemAPI)

## 📝 Descrição

A **LoginSystemAPI** é uma API RESTful desenvolvida para autenticação de usuários.  
Permite login seguro com autenticação baseada em tokens JWT, validação de credenciais e proteção de rotas para acesso apenas de usuários autenticados.

## 🚀 Funcionalidades

- **Login seguro**: Autenticação via usuário e senha com senha criptografada (hash + salt)
- **Geração de Token JWT**: Expiração configurável, Issuer/Audience e proteção de rotas
- **Proteção de Rotas**: Rotas seguras com [Authorize]
- **Seed de Usuário**: Usuário padrão criado automaticamente para testes
- **Documentação Swagger**: API totalmente documentada
- **Testes Automatizados**: Testes com xUnit e Moq para garantir qualidade

---

## 📋 Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)
- Visual Studio ou VS Code

---

## 🛠️ Configuração do Projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/MatheusAV/LoginSystem.git
   cd LoginSystem
   ```

2. Instale as dependências do projeto:

   ```bash
   dotnet restore
   ```

3. Configure o banco de dados no arquivo `appsettings.json`:
   ```bash
   json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=LoginSystem;Trusted_Connection=True;"
   }
   ```

5. Execute as migrations para configurar o banco:
   ```bash
   dotnet ef database update --project LoginSystem.Infrastructure
   ```

6. Execute a aplicação:
   ```bash
     dotnet run --project LoginSystem.Api
   ```
6. Acesse a documentação Swagger em `http://localhost:5000/swagger`.

## 📂 Estrutura do Projeto

```plaintext
LoginSystem/
├── LoginSystem.Api/               # API (Web API)
├── LoginSystem.Application/       # Aplicação (Services + DTOs)
├── LoginSystem.Domain/            # Domínio (Entidades + Regras)
├── LoginSystem.Infrastructure/   # Infraestrutura (Banco de dados + Repositórios)
├── LoginSystem.Tests/             # Testes automatizados
└── README.md
```
---


