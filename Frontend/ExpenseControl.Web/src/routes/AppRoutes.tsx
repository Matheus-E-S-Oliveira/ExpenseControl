import { BrowserRouter, Routes, Route } from "react-router-dom";
import DashboardPage from "../features/dashboard/page/DashboardPage";
import PersonsListPage from "../features/persons/pages/PersonsListPage";
import CategoriesListPage from "../features/categories/pages/CategoryListPage";
import TransactionsListPage from "../features/transactions/pages/TransactionsListPage";

/**
 * AppRoutes - Configuração das rotas da aplicação
 * 
 * Lógica:
 * - BrowserRouter: componente que habilita o roteamento no frontend React
 * - Routes: container que agrupa todas as rotas
 * - Route: define cada rota, mapeando path para componente
 * 
 * Rotas definidas:
 * - "/" → DashboardPage: página inicial com resumo geral
 * - "/persons" → PersonsListPage: listagem de pessoas cadastradas
 * - "/categories" → CategoriesListPage: listagem de categorias
 * - "/transactions" → TransactionsListPage: listagem de transações
 * 
 * Observações:
 * - Cada rota renderiza seu componente principal correspondente
 * - Facilita navegação e organização da aplicação
 */

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        {/* Página inicial: dashboard com resumo geral */}
        <Route path="/" element={<DashboardPage />} />

        {/* Tela de listagem de pessoas */}
        <Route path="/persons" element={<PersonsListPage />} />

        {/* Tela de listagem de categorias */}
        <Route path="/categories" element={<CategoriesListPage />} />

        {/* Tela de listagem de transações */}
        <Route path="/transactions" element={<TransactionsListPage />} />
      </Routes>
    </BrowserRouter>
  );
}
