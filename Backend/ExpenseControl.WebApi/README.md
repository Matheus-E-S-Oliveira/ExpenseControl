# ExpenseControl - Sistema de Controle de Gastos Residenciais

## Visão Geral
O **ExpenseControl** é uma aplicação backend em .NET 9 para gerenciar gastos e receitas residenciais.  
Permite cadastrar pessoas, categorias e transações, além de gerar resumos de dashboard com totais de receitas, despesas e saldo.  

O projeto segue arquitetura **Clean Architecture**, separando responsabilidades:

- **Domain**: entidades, enums e interfaces de repositório.
- **Infrastructure**: contexto do banco (EF Core), configurações e implementações de repositórios.
- **Application**: serviços de negócio e validações (FluentValidation).
- **Endpoints**: controllers, requests e responses da API REST.

---

## Tecnologias
- .NET 9
- C#
- Entity Framework Core (versão compatível com .NET 9)
- FluentValidation
- ASP.NET Core Web API
- MySQL ou outro banco relacional compatível com EF Core
- Swagger / OpenAPI (`Swashbuckle.AspNetCore`)

---

## Entidades (Domain)

### Category
Representa uma categoria de transação (despesa, receita ou ambas).  

**Propriedades**:
- `Id` (Guid)
- `Description` (string, até 400 caracteres)
- `Purpose` (CategoryPurpose: Expense, Income, Both, None)
- `CreatedAt`, `UpdatedAt` (DateTime?)

**Métodos**:
- `Create(description, purpose)` → Cria uma nova categoria
- `Update(description, purpose)` → Atualiza dados da categoria

### Person
Representa uma pessoa do sistema.  

**Propriedades**:
- `Id` (Guid)
- `Name` (string, até 200 caracteres)
- `Age` (int)
- `CreatedAt`, `UpdatedAt` (DateTime?)
- `Transactions` (coleção de transações da pessoa)

**Métodos**:
- `Create(name, age)` → Cria uma nova pessoa
- `Update(name, age)` → Atualiza dados da pessoa

### Transaction
Representa uma transação financeira.  

**Propriedades**:
- `Id` (Guid)
- `PersonId`, `CategoryId` (Guid)
- `Description` (string, até 400 caracteres)
- `Value` (decimal)
- `Type` (TransactionType: Expense, Income, None)
- `CreatedAt`, `UpdatedAt` (DateTime?)

**Métodos**:
- `Create(personId, categoryId, description, value, type)` → Cria uma nova transação

---

## Requests (API Input)

**CategoryRequest**
```csharp
public class CategoryRequest
{
    public string Description { get; set; }
    public CategoryPurpose Purpose { get; set; }
}
```

**PersonRequest**
```csharp
public class PersonRequest
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

**TransactionRequest**
```csharp
public class TransactionRequest
{
    public Guid PersonId { get; init; }
    public Guid CategoryId { get; init; }
    public string Description { get; init; }
    public decimal Value { get; init; }
    public TransactionType Type { get; init; }
}
```

---

## Responses (API Output)

Todas as respostas seguem o padrão **ApiResponse<T>**:

- `Success` → operação bem-sucedida (bool)
- `StatusCode` → HTTP status code
- `Data` → objeto ou lista do tipo T
- `Message` → mensagem de retorno
- `Errors` → lista de erros (opcional)

**Exemplos de Response**:
- `CategoryResponse` → dados de uma categoria
- `PersonResponse` → dados de uma pessoa
- `TransactionResponse` → dados de uma transação
- `DashboardSummaryResponse` → resumo financeiro geral, incluindo pessoas, categorias e últimas transações

---

## Services
Os services encapsulam a lógica de negócio e chamam os repositórios:

- **CategoryService** → GetById, GetAll, Create
- **PersonService** → GetById, GetAll, Create, Update, Delete
- **TransactionService** → GetById, GetAll, Create (com validações de idade e compatibilidade de categoria)
- **DashboardService** → Retorna resumo de receitas, despesas, saldo, pessoas, categorias e últimas transações

---

## Validações
Usando **FluentValidation**:

- **CategoryValidator** → descrição obrigatória e até 400 caracteres, finalidade válida
- **PersonValidator** → nome obrigatório, idade entre 0 e 120
- **TransactionValidator** → descrição obrigatória até 400 caracteres, valor > 0 e ≤ 1 milhão, tipo válido, PersonId e CategoryId obrigatórios

---

## Controllers (API Endpoints)

**CategoryController**
- `GET /api/category` → Lista todas as categorias
- `GET /api/category/{id}` → Busca categoria por id
- `POST /api/category` → Cria nova categoria

**PersonController**
- `GET /api/person` → Lista todas as pessoas
- `GET /api/person/{id}` → Busca pessoa por id
- `POST /api/person` → Cria nova pessoa
- `PUT /api/person/{id}` → Atualiza pessoa
- `DELETE /api/person/{id}` → Remove pessoa

**TransactionController**
- `GET /api/transaction` → Lista todas as transações
- `GET /api/transaction/{id}` → Busca transação por id
- `POST /api/transaction` → Cria nova transação

**DashboardController**
- `GET /api/dashboard` → Retorna resumo financeiro geral

---

## Banco de Dados
- Implementado com **EF Core**
- Contexto: `ExpenseControlContext`
- Entidades mapeadas usando `IEntityTypeConfiguration<T>`:
  - CategoryConfiguration
  - PersonConfiguration
  - TransactionConfiguration
- Migrations via CLI do .NET:
```bash
dotnet ef migrations add <NomeDaMigration>
dotnet ef database update
```

---

## Inicialização e Serviços (Program.cs & Extensões)

A inicialização da aplicação é modular, usando extensões para registrar serviços, repositórios e validações:

**ServiceExtensions**
- `AddApplicationServices()` → registra serviços de negócio
- `AddRepositories()` → registra repositórios
- `ConfigureCustomValidation()` → padroniza respostas de erro do ModelState

**Program.cs**
1. Registra controllers, Swagger/OpenAPI e CORS
2. Configura ExpenseControlContext (EF Core + MySQL)
3. Registra validators (FluentValidation)
4. Registra serviços e repositórios via extensões
5. Configura middlewares: CORS, HTTPS, Authorization, MapControllers
6. Swagger disponível em ambiente de desenvolvimento

---

## Observações Importantes
- Todas as datas são armazenadas em UTC (`DateTime.UtcNow`)
- Transações de menores de 18 anos só podem ser **despesas**
- Categoria deve ser compatível com o tipo da transação
- Valores máximos de transação: até 1 milhão

---

## Exemplos de Uso (C#)
```csharp
// Criar pessoa
var person = await personService.CreateAsync(new PersonRequest { Name = "Matheus", Age = 25 });

// Criar categoria
var category = await categoryService.CreateAsync(new CategoryRequest { Description = "Alimentação", Purpose = CategoryPurpose.Expense });

// Criar transação
var transaction = await transactionService.CreateAsync(new TransactionRequest
{
    PersonId = person.Data.Id,
    CategoryId = category.Data.Id,
    Description = "Compra supermercado",
    Value = 150.50m,
    Type = TransactionType.Expense
});

// Obter dashboard
var dashboard = await dashboardService.GetDashboardSummaryAsync();
```

> Este README fornece documentação completa do projeto **ExpenseControl**, integrando entidades, requests, responses, services, controllers, validações, regras de negócio e exemplos práticos de uso.
