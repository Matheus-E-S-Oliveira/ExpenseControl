# ExpenseControl - Controle de Gastos Residenciais

O **ExpenseControl** é uma aplicação full-stack para gerenciar gastos e receitas residenciais, permitindo cadastrar pessoas, categorias e transações, além de acompanhar resumos financeiros no dashboard.

---

## Tecnologias

**Backend:** .NET 9, C#, ASP.NET Core Web API, Entity Framework Core, FluentValidation, MySQL (ou outro banco compatível), Swagger/OpenAPI.

**Frontend:** React + TypeScript, Axios, TailwindCSS, Hooks e componentes funcionais.

---

## Instalação e Execução

### Backend

1. Configure sua **connection string** no `appsettings.json`.
2. Execute o comando para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```
3. Inicie o servidor:

   ```bash
   dotnet run
   ```
4. A API estará disponível em `http://localhost:5186`.

### Frontend

1. Instale as dependências:

   ```bash
   npm install
   ```
2. Inicie o servidor de desenvolvimento:

   ```bash
   npm run dev
   ```
3. A aplicação estará disponível em `http://localhost:5173`.

---

## Funcionalidades Principais

* **Dashboard**: resumo de receitas, despesas e saldo, últimas transações.
* **Pessoas**: listagem, criação, edição e exclusão.
* **Categorias**: listagem e criação.
* **Transações**: registro de despesas e receitas com validações.
* **Modais Globais**: mensagens de sucesso/erro e confirmações de ações.

---

## Observações

* Todas as datas são armazenadas em UTC.
* Menores de 18 anos só podem registrar despesas.
* Categorias devem ser compatíveis com o tipo da transação.
* Valores máximos de transação: até 1 milhão.
