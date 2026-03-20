import { BrowserRouter, Routes, Route } from "react-router-dom";
import DashboardPage from "../features/dashboard/page/DashboardPage";
import PersonsListPage from "../features/persons/pages/PersonsListPage";

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DashboardPage />} />
        <Route path="/person" element={<PersonsListPage />} />
      </Routes>
    </BrowserRouter>
  );
}
