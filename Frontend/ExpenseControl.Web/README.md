## Rotas da Aplicação
- **/** → Dashboard: página inicial com resumo geral de gastos e receitas
- **/persons** → Pessoas: listagem e gerenciamento de pessoas
- **/categories** → Categorias: listagem e gerenciamento de categorias
- **/transactions** → Transações: listagem e gerenciamento de transações

## Layout Principal
- **MainLayout**: organiza a estrutura de todas as páginas
  - **Header**: topo da página
  - **Main**: área centralizada para conteúdo dinâmico (`children`)
  - **Footer**: rodapé fixo
- Garantia de altura total, rolagem automática e consistência de fonte

## Cabeçalho (Header)
- Barra fixa no topo da aplicação
- Menu de navegação com links para:
  - Dashboard
  - Pessoas
  - Categorias
  - Transações
- Destaca a rota ativa em azul
- Exibe título da aplicação ao lado direito

## Rodapé (Footer)
- Fixo na base do layout principal
- Exibe:
  - Texto de copyright
  - Link para repositório GitHub com ícone
- Estilização:
  - Fundo branco, cantos arredondados e sombra
  - Fonte em itálico

## Modal de Confirmação (ConfirmationModal)
- Reutilizável em toda a aplicação
- Props:
  - `message`: mensagem exibida no modal
  - `onConfirm`: ação ao confirmar
  - `onCancel`: ação ao cancelar
- Layout:
  - Overlay semi-transparente cobrindo toda a tela
  - Caixa centralizada com mensagem e botões
  - Botões estilizados com cores distintas para Cancelar e Confirmar

## Modal Global (ModalGlobal)
- Modal genérico para exibir mensagens de sucesso ou erro
- Props:
  - `message`: mensagem exibida no modal
  - `onClose`: função chamada ao fechar
  - `success` (opcional): define se é sucesso (true) ou erro (false)
- Layout:
  - Overlay semi-transparente cobrindo toda a tela
  - Caixa centralizada com mensagem e botão de fechar
  - Cor do texto e do botão muda conforme `success`

## Dashboard
- Página principal com resumo financeiro da aplicação
- Seções:
  - **Resumo Geral**: cards de Receita Total, Despesa Total e Saldo, com cores condicionais
  - **Pessoas**: lista de pessoas cadastradas, mostrando receita, gastos e saldo
  - **Categorias**: lista de categorias, mostrando receita, gastos e saldo por categoria
  - **Transações Recentes**: últimas transações, mostrando autor, descrição, tipo e valor
- Layout:
  - Duas colunas: esquerda (Resumo + Pessoas), direita (Categorias + Transações)
  - Estilização com caixas brancas, bordas arredondadas, sombra e espaçamento
  - Valores monetários formatados em Real (R$) com 2 casas decimais

## Dashboard Service
- Responsável por buscar dados financeiros para o Dashboard
- Função principal: `getDashboardSummary()`
  - Retorna resumo financeiro:
    - Receita total, Despesa total, Saldo
    - Lista de pessoas com receita, gastos e saldo
    - Lista de categorias com receita, gastos e saldo
    - Últimas transações com descrição, autor, tipo e valor
- Tipos utilizados:
  - PersonSummary, CategorySummary, TransactionSummary, DashboardSummary
- Faz requisição GET para `http://localhost:5186/api/dashboard`

## Dashboard Hook
- Hook `useDashboard()` para consumir os dados do Dashboard
- Estados retornados:
  - `data`: resumo financeiro completo (DashboardSummary)
  - `loading`: indica se a requisição ainda está em andamento
  - `error`: mensagem de erro caso a requisição falhe
- Faz a chamada ao service `getDashboardSummary()`
- Utilizado em `DashboardPage` para exibir cards, pessoas, categorias e transações

## Pessoas
- Página de listagem e gerenciamento de pessoas
- Funcionalidades:
  - Listagem de todas as pessoas cadastradas
  - Filtro por nome e idade
  - Criação e edição via modal (PersonFormModal)
  - Exclusão com confirmação (ConfirmationModal)
  - Mensagens de sucesso ou erro via ModalGlobal
- Layout:
  - Cards individuais para cada pessoa (PersonCard)
  - Responsivo e organizado com flex-wrap
  - Mensagens de estado (nenhuma pessoa ou filtro sem resultados)

## PersonFormModal
- Modal para criação e edição de pessoas
- Funcionalidades:
  - Preenche campos com dados existentes ao editar
  - Valida campos: nome obrigatório, até 200 caracteres; idade >0 e <=120
  - Criação e atualização via API (createPerson / updatePerson)
  - Exibe erros próximos aos inputs
  - Mostra mensagens de sucesso/erro via ModalGlobal
- Layout:
  - Inputs alinhados em coluna
  - Botões Salvar e Cancelar com feedback visual
  - Modal centralizado sobre fundo semitransparente

## PersonFilterCard
- Card de filtros e ações para lista de pessoas
- Funcionalidades:
  - Filtra pessoas por nome e idade
  - Limpa filtros com o botão Limpar
  - Botão Novo abre modal de criação
- Layout:
  - Inputs responsivos alinhados horizontalmente
  - Botões com cores distintas e ícones (`Buscar` azul, `Limpar` cinza, `Novo` verde)
  - Caixa branca com bordas arredondadas, sombra e espaçamento interno

## PersonCard
- Card individual de pessoa usado na lista de pessoas
- Funcionalidades:
  - Exibe nome e idade da pessoa
  - Ícones de ação:
    - Editar (azul) chama `onEdit` se fornecido
    - Excluir (vermelho) chama `onDelete`
- Layout:
  - Caixa branca com bordas arredondadas e sombra
  - Texto à esquerda e ações à direita
  - Nome cortado com ellipsis se for longo
  - Padding interno e espaçamento entre elementos

## PersonService
- Serviço para comunicação com a API de pessoas
- Funções:
  - **getPersons**: busca todas as pessoas cadastradas
  - **createPerson**: cria uma nova pessoa com { name, age }
  - **updatePerson**: atualiza uma pessoa existente pelo id
  - **deletePerson**: exclui uma pessoa pelo id
- Retorno de cada função: dados da API (JSON)

## CategoriesListPage
- Página de listagem e gerenciamento de categorias
- Funcionalidades:
  - Busca categorias da API e aplica filtros (descrição e propósito)
  - Exibe lista de categorias com cards individuais (CategoryCard)
  - Permite cadastrar novas categorias via modal (CategoryFormModal)
  - Exibe mensagens de feedback com ModalGlobal
- Layout:
  - Filtros e botão "Nova Categoria" no topo (CategoryFilterCard)
  - Cards organizados em grid flexível
  - Mensagens de aviso quando lista vazia ou filtrada