import { BrowserRouter, Routes, Route } from "react-router-dom";
import DashboardPage from "../features/dashboard/page/DashboardPage";
import PersonsListPage from "../features/persons/pages/PersonsListPage";
import CategoriesListPage from "../features/categories/pages/CategoryListPage";
import TransactionsListPage from "../features/transactions/pages/TransactionsListPage";

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DashboardPage />} />
        <Route path="/persons" element={<PersonsListPage />} />
        <Route path="/categories" element={<CategoriesListPage />} />
        <Route path="/transactions" element={<TransactionsListPage />} />
      </Routes>
    </BrowserRouter>
  );
}
