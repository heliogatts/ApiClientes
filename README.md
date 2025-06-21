# APIClientes

API RESTful desenvolvida em C# utilizando ASP.NET Core e Entity Framework Core com SQLite. O projeto segue o padrão de arquitetura MVC e permite realizar operações CRUD sobre um domínio de **Clientes**.

---

## 🔧 Tecnologias utilizadas

- [.NET 6 ou superior](https://dotnet.microsoft.com/download)
- ASP.NET Core
- Entity Framework Core
- SQLite

---

## 📁 Estrutura do Projeto

```
ApiClientes/
├── Controllers/
│   └── ClientesController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── Cliente.cs
├── apiclientes.http
├── Program.cs
├── README.md
├── clientes.db (gerado automaticamente)
```

---

## 🚀 Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/APIClientes.git
cd APIClientes
```

### 2. Restaurar dependências

```bash
dotnet restore
```

### 3. Criar a base de dados com EF Core

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> 💡 Caso ainda não tenha, instale a ferramenta de migração:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Executar a aplicação

```bash
dotnet run
```

A aplicação será iniciada com Swagger em:  
📍 `https://localhost:{porta}/swagger`

---

## 📬 Endpoints da API

| Método | Endpoint                           | Descrição                          |
|--------|------------------------------------|------------------------------------|
| GET    | `/api/clientes`                   | Lista todos os clientes            |
| GET    | `/api/clientes/count`             | Retorna a quantidade total         |
| GET    | `/api/clientes/{id}`              | Busca cliente por ID               |
| GET    | `/api/clientes/search?name=João`  | Busca cliente por nome             |
| POST   | `/api/clientes`                   | Cria um novo cliente               |
| PUT    | `/api/clientes/{id}`              | Atualiza um cliente existente      |
| DELETE | `/api/clientes/{id}`              | Remove um cliente                  |

---

## 🧪 Testando com o arquivo `apiclientes.http`

1. Instale a extensão **REST Client** no Visual Studio Code.
2. Abra o arquivo `apiclientes.http` incluído no projeto.
3. Clique em **"Send Request"** acima de qualquer requisição.

### Conteúdo de exemplo (`apiclientes.http`):

```http
@baseUrl = https://localhost:5001/api/clientes

### 🔄 Criar um cliente
POST {{baseUrl}}
Content-Type: application/json

{
  "nome": "João Silva",
  "email": "joao.silva@email.com"
}

###

### 📋 Listar todos os clientes
GET {{baseUrl}}

###

### 🔍 Buscar cliente por ID
GET {{baseUrl}}/1

###

### 🔍 Buscar cliente por nome
GET {{baseUrl}}/search?name=João

###

### 🔢 Contar total de clientes
GET {{baseUrl}}/count

###

### ✏️ Atualizar cliente
PUT {{baseUrl}}/1
Content-Type: application/json

{
  "id": 1,
  "nome": "João Atualizado",
  "email": "joao.atualizado@email.com"
}

###

### ❌ Deletar cliente
DELETE {{baseUrl}}/1
```

> ⚠️ Verifique a porta no terminal após executar `dotnet run`, e atualize `{{baseUrl}}` se necessário.

---

## 🗃️ Banco de Dados

- Banco: **SQLite**
- Arquivo: `clientes.db`
- Criado automaticamente via EF Core ao rodar:
  ```bash
  dotnet ef database update
  ```

---

## 🧱 Padrão de Arquitetura

Este projeto segue o padrão **MVC (Model-View-Controller)**:
- **Model**: `Cliente.cs`
- **View**: não aplicável (API REST não possui interface visual)
- **Controller**: `ClientesController.cs`
- **DbContext**: `AppDbContext.cs` para abstração da base de dados

---

## 📌 Observações

- API limpa e simples, ideal para fins educacionais.
- Modularidade e separação de responsabilidades com foco em boas práticas.
- Pronto para extensão (ex.: autenticação, versionamento, camadas de serviço etc.)

---

## 📄 Licença

Este projeto é distribuído sob a licença MIT.

---

## ✍️ Autor

Desenvolvido com fins didáticos para estudo de **C# + ASP.NET Core + SQLite + Arquitetura MVC**.
