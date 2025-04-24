```markdown
# KanbanAPI

Uma API RESTful desenvolvida em **C# com ASP.NET Core**, utilizando **SQL Server em Docker** como banco de dados. O sistema permite o gerenciamento de quadros (boards) e cartões (cards) no estilo Kanban, com operações completas de criação, leitura, atualização e exclusão.

---

## 🚀 Tecnologias

- .NET 8 / ASP.NET Core
- Entity Framework Core (Code First)
- SQL Server (via Docker)
- Swagger (OpenAPI)
- Docker & Docker Compose

---

## 📦 Funcionalidades

- **Boards**
  - Criar, listar, editar e excluir quadros Kanban
  - Registro automático da data de criação

- **Cards**
  - Vincular cartões a quadros específicos
  - Definir título, descrição e status (`To Do`, `Doing`, `Done`)
  - Atualizar e excluir cartões

- Interface de testes via Swagger
- Arquitetura RESTful simples e extensível

---

## 🐳 Como executar com Docker

### 1. Clonar o repositório

```bash
git clone https://github.com/seuusuario/KanbanAPI.git
cd KanbanAPI
```

### 2. Subir os containers

```bash
docker-compose up --build -d
```

### 3. Aplicar as migrações do banco de dados

```bash
docker run --rm \
  --network=kanbanapi_kanban-network \
  -v $(pwd):/app -w /app \
  mcr.microsoft.com/dotnet/sdk:8.0 \
  bash -c "dotnet tool install --global dotnet-ef && export PATH=\"\$PATH:/root/.dotnet/tools\" && dotnet ef database update"
```

---

## 🔍 Acesso à API

A documentação interativa está disponível em:

```
http://localhost:5000/swagger
```

---

## 📁 Endpoints principais

### Boards
- `GET /api/boards`
- `GET /api/boards/{id}`
- `POST /api/boards`
- `PUT /api/boards/{id}`
- `DELETE /api/boards/{id}`

### Cards
- `GET /api/cards/board/{boardId}`
- `POST /api/cards/board/{boardId}`
- `PUT /api/cards/{id}`
- `DELETE /api/cards/{id}`

---

## 🔧 Próximas melhorias

- Adição de testes unitários com xUnit
- Organização das variáveis de ambiente (.env)
- Integração opcional com RabbitMQ para eventos assíncronos
- Volume Docker para persistência de dados
- Interface frontend leve para visualização dos dados

---

## 👤 Autor

**Rian Santana**  
Desenvolvedor Full-Stack  
[GitHub](https://github.com/RianRBPS) · [LinkedIn](https://www.linkedin.com/in/riansantana/)
```
