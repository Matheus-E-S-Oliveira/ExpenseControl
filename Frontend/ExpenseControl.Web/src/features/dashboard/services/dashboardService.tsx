// services/dashboardService.ts
import axios from "axios";

const API_URL = "http://localhost:5186/api/dashboard";

export type PersonSummary = {
  name: string;
  age: number;
  totalIncome: number;
  totalExpenses: number;
  balance: number;
};

export type CategorySummary = {
  description: string;
  totalIncome: number;
  totalExpenses: number;
  balance: number;
};

export type TransactionSummary = {
    description: string;
    personName: string;
    type: number;
    value: number;
}

export type DashboardSummary = {
  totalIncome: number;
  totalExpenses: number;
  balance: number;
  people: PersonSummary[];
  categories: CategorySummary[];
  recentTransactions: TransactionSummary[];
};

type ApiResponse<T> = {
  success: boolean;
  statusCode: number;
  data: T;
  message: string;
  errors?: any;
};

export const getDashboardSummary = async (): Promise<DashboardSummary> => {
  const response = await axios.get<ApiResponse<DashboardSummary>>(API_URL);
  return response.data.data;
};